using System.Security.Claims;
using Jcf.QuinzePontos.Application.Auth.Interfaces.Services;
using Jcf.QuinzePontos.Application.Auth.Models.DTOs;
using Jcf.QuinzePontos.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.QuinzePontos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var result = await _authService.LoginAsync(dto);
            if (!result.Success)
                return Unauthorized(new { errors = result.Errors });

            return Ok(result);
        }

        [HttpPost("register")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO dto)
        {
            var createdByUserId = GetCurrentUserId();

            var result = await _authService.RegisterAsync(dto, createdByUserId);
            if (!result.Success)
                return BadRequest(new { errors = result.Errors });

            return Ok(result);
        }

        private Guid? GetCurrentUserId()
        {
            var value = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(value, out var userId) ? userId : null;
        }
    }
}
