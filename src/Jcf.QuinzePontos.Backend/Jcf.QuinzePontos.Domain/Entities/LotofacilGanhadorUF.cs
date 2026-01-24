using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.QuinzePontos.Domain.Entities
{
    public class LotofacilGanhadorUF : EntityBase
    {
        public long ConcursoId { get; private set; }

        [ForeignKey(nameof(ConcursoId))]
        public LotofacilConcurso Concurso { get; set; } = null!;

        public string UF { get; set; } = string.Empty;
        public string Municipio { get; set; } = string.Empty;
        public int Ganhadores { get; set; }
    }
}
