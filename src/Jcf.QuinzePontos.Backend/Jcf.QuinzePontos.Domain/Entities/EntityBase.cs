using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.QuinzePontos.Domain.Entities
{
    public class EntityBase
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private set; }

        [Required]
        public Guid Uid { get; private set; } = Guid.NewGuid();

        [Required]
        public bool IsActive { get; private set; } = true;

        [Required]
        public DateTime CreateAt { get; private set; } = DateTime.UtcNow;

        public DateTime? UpdateAt { get; private set; }

        public EntityBase() { }
    }
}
