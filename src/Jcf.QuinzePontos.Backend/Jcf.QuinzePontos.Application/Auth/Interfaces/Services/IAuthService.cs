using Jcf.QuinzePontos.Application.Auth.Models.DTOs;

namespace Jcf.QuinzePontos.Application.Auth.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthResultDTO> RegisterAsync(RegisterUserDTO dto, Guid? createdByUserId);
        Task<AuthResultDTO> LoginAsync(LoginDTO dto);
    }
}
