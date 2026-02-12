namespace Jcf.QuinzePontos.Application.LotofacilConcurso.Models.DTOs
{
    public class LotofacilRateioDTO
    {
        public int Faixa { get; private set; }
        public string DescricaoFaixa { get; private set; } = string.Empty;
        public int NumeroDeGanhadores { get; private set; }
        public decimal ValorPremio { get; private set; }
    }
}
