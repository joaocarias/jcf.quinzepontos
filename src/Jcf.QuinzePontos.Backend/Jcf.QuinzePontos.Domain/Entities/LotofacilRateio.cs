using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.QuinzePontos.Domain.Entities
{
    public class LotofacilRateio : EntityBase
    {
        public long ConcursoId { get; private set; }

        [ForeignKey(nameof(ConcursoId))]
        public LotofacilConcurso Concurso { get; private set; } = null!;

        public int Faixa { get; private set; }
        public string DescricaoFaixa { get; private set; } = string.Empty;
        public int NumeroDeGanhadores { get; private set; }
        public decimal ValorPremio { get; private set; }
    }
}
