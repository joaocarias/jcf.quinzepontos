namespace Jcf.QuinzePontos.Domain.Entities
{
    public class LotofacilConcurso : EntityBase
    {
        public LotofacilConcurso(int numero, DateTime dataApuracao, DateTime dataProximoConcurso, bool acumulado, bool ultimoConcurso, string localSorteio, string nomeMunicipioUFSorteio, string observacao, decimal valorArrecadado, decimal valorEstimadoProximoConcurso, decimal valorAcumuladoProximoConcurso, decimal valorAcumuladoConcursoEspecial, LotofacilDezenas? dezenas, ICollection<LotofacilRateio> rateios, ICollection<LotofacilGanhadorUF> ganhadoresUF)
        {
            Numero = numero;
            DataApuracao = dataApuracao;
            DataProximoConcurso = dataProximoConcurso;
            Acumulado = acumulado;
            UltimoConcurso = ultimoConcurso;
            LocalSorteio = localSorteio;
            NomeMunicipioUFSorteio = nomeMunicipioUFSorteio;
            Observacao = observacao;
            ValorArrecadado = valorArrecadado;
            ValorEstimadoProximoConcurso = valorEstimadoProximoConcurso;
            ValorAcumuladoProximoConcurso = valorAcumuladoProximoConcurso;
            ValorAcumuladoConcursoEspecial = valorAcumuladoConcursoEspecial;
            Dezenas = dezenas;
            Rateios = rateios;
            GanhadoresUF = ganhadoresUF;
        }

        public LotofacilConcurso() { }

        public int Numero { get; private set; }
        public DateTime DataApuracao { get; private set; }
        public DateTime? DataProximoConcurso { get; private set; }

        public bool? Acumulado { get; private set; }
        public bool? UltimoConcurso { get; private set; }

        public string? LocalSorteio { get; private set; }  
        public string? NomeMunicipioUFSorteio { get; private set; }
        public string? Observacao { get; private set; } 

        public decimal? ValorArrecadado { get; private set; }
        public decimal? ValorEstimadoProximoConcurso { get; private set; }
        public decimal? ValorAcumuladoProximoConcurso { get; private set; }
        public decimal? ValorAcumuladoConcursoEspecial { get; private set; }

        public LotofacilDezenas? Dezenas { get; private set; } 
        public ICollection<LotofacilRateio> Rateios { get; private set; } = new List<LotofacilRateio>();
        public ICollection<LotofacilGanhadorUF> GanhadoresUF { get; private set; } = new List<LotofacilGanhadorUF>();

        public void SetRelations(LotofacilDezenas? dezenas, ICollection<LotofacilRateio> rateios, ICollection<LotofacilGanhadorUF> ganhadoresUF)
        {
            Dezenas = dezenas;
            Rateios = rateios;
            GanhadoresUF = ganhadoresUF;
        }
    }
}
