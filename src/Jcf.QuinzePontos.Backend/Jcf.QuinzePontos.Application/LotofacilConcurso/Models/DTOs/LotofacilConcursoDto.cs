namespace Jcf.QuinzePontos.Application.LotofacilConcurso.Models.DTOs
{
    public class LotofacilConcursoDto
    {
        public int Numero { get; set; }
        public DateTime DataApuracao { get; set; }
        public DateTime DataProximoConcurso { get; set; }

        public bool Acumulado { get; set; }
        public bool UltimoConcurso { get; set; }

        public string LocalSorteio { get; set; } = string.Empty;
        public string NomeMunicipioUFSorteio { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;

        public decimal ValorArrecadado { get; set; }
        public decimal ValorEstimadoProximoConcurso { get; set; }
        public decimal ValorAcumuladoProximoConcurso { get; set; }
        public decimal ValorAcumuladoConcursoEspecial { get; set; }

    }
}
