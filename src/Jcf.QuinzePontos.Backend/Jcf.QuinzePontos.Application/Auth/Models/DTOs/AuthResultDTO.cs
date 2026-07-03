namespace Jcf.QuinzePontos.Application.Auth.Models.DTOs
{
    public class AuthResultDTO
    {
        public bool Success { get; set; }
        public IReadOnlyCollection<string> Errors { get; set; } = [];
        public string? Token { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public Guid? UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public IReadOnlyCollection<string> Roles { get; set; } = [];

        public static AuthResultDTO Fail(params string[] errors) => new() { Success = false, Errors = errors };
    }
}
