using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.QuinzePontos.Domain.Entities
{
    public class LotofacilDezena : EntityBase
    {
        public Guid ConcursoId { get; private set; }

        [ForeignKey(nameof(ConcursoId))]
        public LotofacilConcurso Concurso { get; private set; } = null!;

        public int Numero { get; private set; }
    }
}
