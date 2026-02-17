using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.QuinzePontos.Domain.Entities
{
    public class LotofacilRateio : EntityBase
    {
        public LotofacilRateio(int faixa, string descricaoFaixa, int numeroDeGanhadores, decimal valorPremio)
        {
            Faixa = faixa;
            DescricaoFaixa = descricaoFaixa;
            NumeroDeGanhadores = numeroDeGanhadores;
            ValorPremio = valorPremio;
        }

        public LotofacilRateio() { }

        public long? LotofacilConcursoId { get; private set; }

        [ForeignKey(nameof(LotofacilConcursoId))]
        public LotofacilConcurso? LotofacilConcurso { get; private set; }

        public int? Faixa { get; private set; }
        public string? DescricaoFaixa { get; private set; }
        public int? NumeroDeGanhadores { get; private set; }
        public decimal? ValorPremio { get; private set; }
    }
}
