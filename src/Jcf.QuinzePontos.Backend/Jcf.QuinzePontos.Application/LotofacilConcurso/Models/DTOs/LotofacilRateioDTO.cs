using Jcf.QuinzePontos.Domain.Entities;

namespace Jcf.QuinzePontos.Application.LotofacilConcurso.Models.DTOs
{
    public class LotofacilRateioDTO
    {
        public int Faixa { get; set; }
        public string DescricaoFaixa { get; set; } = string.Empty; 
        public int NumeroDeGanhadores { get; set; }
        public decimal ValorPremio { get; set; }

        public LotofacilRateio ToLotofacilRateio()
        {
            var entity = new LotofacilRateio(
                    this.Faixa,
                    this.DescricaoFaixa,
                    this.NumeroDeGanhadores,
                    this.ValorPremio
                );

            return entity;
        }
    }   
}
