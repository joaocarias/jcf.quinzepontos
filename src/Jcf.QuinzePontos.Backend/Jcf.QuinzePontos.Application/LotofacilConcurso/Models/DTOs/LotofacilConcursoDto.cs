namespace Jcf.QuinzePontos.Application.LotofacilConcurso.Models.DTOs
{
    public class LotofacilConcursoDTO
    {
        public long? Id { get; set; } 

        public bool Acumulado { get; set; }
        public string? DataApuracao { get; set; }
        public string? DataProximoConcurso { get; set; }
        
        public int Numero { get; set; }
        public bool UltimoConcurso { get; set; }

        public string LocalSorteio { get; set; } = string.Empty;
        public string NomeMunicipioUFSorteio { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;

        public decimal ValorArrecadado { get; set; }
        public decimal ValorEstimadoProximoConcurso { get; set; }
        public decimal ValorAcumuladoProximoConcurso { get; set; }
        public decimal ValorAcumuladoConcursoEspecial { get; set; }

        public ICollection<int> ListaDezenas { get; set; } = [];
        public ICollection<LotofacilGanhadorUFDTO> ListaMunicipioUFGanhadores { get; set; } = [];
        public ICollection<LotofacilRateioDTO> ListaRateioPremio { get; set; } = []; 
    }
}
