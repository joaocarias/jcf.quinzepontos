using Microsoft.AspNetCore.Identity;

namespace Jcf.QuinzePontos.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser(string fullName, string email, string? phoneNumber)
        {
            FullName = fullName;
            Email = email;
            UserName = email;
            PhoneNumber = phoneNumber;
        }

        public ApplicationUser() { }

        public string FullName { get; set; } = string.Empty;

        public bool IsActive { get; private set; } = true;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public Guid? UserCreatedId { get; private set; }
        public DateTime? UpdateAt { get; private set; }
        public Guid? UserUpdateId { get; private set; }

        public void SetCreationAudit(Guid? userCreatedId)
        {
            UserCreatedId = userCreatedId;
        }

        public void SetUpdateAudit(Guid? userUpdateId)
        {
            UpdateAt = DateTime.UtcNow;
            UserUpdateId = userUpdateId;
        }

        public void Deactivate(Guid? userUpdateId)
        {
            IsActive = false;
            SetUpdateAudit(userUpdateId);
        }

        public void Activate(Guid? userUpdateId)
        {
            IsActive = true;
            SetUpdateAudit(userUpdateId);
        }
    }
}
