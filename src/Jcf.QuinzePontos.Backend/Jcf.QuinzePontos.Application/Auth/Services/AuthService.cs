using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Jcf.QuinzePontos.Application.Auth.Interfaces.Services;
using Jcf.QuinzePontos.Application.Auth.Models.DTOs;
using Jcf.QuinzePontos.Application.Auth.Options;
using Jcf.QuinzePontos.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Jcf.QuinzePontos.Application.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly JwtOptions _jwtOptions;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            IOptions<JwtOptions> jwtOptions,
            ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtOptions = jwtOptions.Value;
            _logger = logger;
        }

        public async Task<AuthResultDTO> RegisterAsync(RegisterUserDTO dto, Guid? createdByUserId)
        {
            if (!await _roleManager.RoleExistsAsync(dto.Role))
                return AuthResultDTO.Fail("Role informada é inválida.");

            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
                return AuthResultDTO.Fail("Já existe um usuário cadastrado com este e-mail.");

            var user = new ApplicationUser(dto.FullName, dto.Email, dto.PhoneNumber);
            user.SetCreationAudit(createdByUserId);

            var createResult = await _userManager.CreateAsync(user, dto.Password);
            if (!createResult.Succeeded)
                return AuthResultDTO.Fail(createResult.Errors.Select(e => e.Description).ToArray());

            await _userManager.AddToRoleAsync(user, dto.Role);

            _logger.LogInformation("Usuário {Email} criado com a role {Role}.", dto.Email, dto.Role);

            return new AuthResultDTO
            {
                Success = true,
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Roles = [dto.Role]
            };
        }

        public async Task<AuthResultDTO> LoginAsync(LoginDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null || !user.IsActive)
                return AuthResultDTO.Fail("E-mail ou senha inválidos.");

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, lockoutOnFailure: true);

            if (signInResult.IsLockedOut)
                return AuthResultDTO.Fail("Usuário bloqueado temporariamente por excesso de tentativas. Tente novamente mais tarde.");

            if (!signInResult.Succeeded)
                return AuthResultDTO.Fail("E-mail ou senha inválidos.");

            var roles = await _userManager.GetRolesAsync(user);
            var (token, expiresAt) = GenerateJwtToken(user, roles);

            return new AuthResultDTO
            {
                Success = true,
                Token = token,
                ExpiresAt = expiresAt,
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Roles = [.. roles]
            };
        }

        private (string Token, DateTime ExpiresAt) GenerateJwtToken(ApplicationUser user, IEnumerable<string> roles)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email ?? string.Empty),
                new(ClaimTypes.Name, user.FullName)
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var expiresAt = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: expiresAt,
                signingCredentials: credentials);

            return (new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
        }
    }
}
