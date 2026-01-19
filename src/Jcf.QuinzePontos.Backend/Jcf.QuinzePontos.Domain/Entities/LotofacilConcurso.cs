namespace Jcf.QuinzePontos.Domain.Entities
{
    public class LotofacilConcurso : EntityBase
    {
        public int Numero { get; private set; }
        public DateTime DataApuracao { get; private set; }
        public DateTime DataProximoConcurso { get; private set; }

        public bool Acumulado { get; private set; }
        public bool UltimoConcurso { get; private set; }

        public string LocalSorteio { get; private set; } = string.Empty;
        public string NomeMunicipioUFSorteio { get; private set; } = string.Empty;
        public string Observacao { get; private set; } = string.Empty;

        public decimal ValorArrecadado { get; private set; }
        public decimal ValorEstimadoProximoConcurso { get; private set; }
        public decimal ValorAcumuladoProximoConcurso { get; private set; }
        public decimal ValorAcumuladoConcursoEspecial { get; private set; }

        public ICollection<LotofacilDezena> Dezenas { get; private set; } = new List<LotofacilDezena>();
        public ICollection<LotofacilRateio> Rateios { get; private set; } = new List<LotofacilRateio>();
        public ICollection<LotofacilGanhadorUF> GanhadoresUF { get; private set; } = new List<LotofacilGanhadorUF>();

    }
}
