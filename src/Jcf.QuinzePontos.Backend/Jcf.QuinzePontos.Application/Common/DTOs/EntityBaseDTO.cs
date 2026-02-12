namespace Jcf.QuinzePontos.Application.Common.DTOs
{
    public class EntityBaseDTO
    {
        public long? Id { get; set; }

        public Guid? Uid { get; set; } 

        public bool IsActive { get; set; } = true;

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdateAt { get; set; }

        public EntityBaseDTO() { }
    }
}

