using Jcf.QuinzePontos.Application.Common.DTOs;
using Jcf.QuinzePontos.Domain.Entities;

namespace Jcf.QuinzePontos.Application.LotofacilConcurso.Models.DTOs
{
    public class LotofacilGanhadorUFDTO 
    {       
        public string UF { get; set; } = string.Empty;
        public string Municipio { get; set; } = string.Empty;
        public int Ganhadores { get; set; }

        public LotofacilGanhadorUF ToLotofacilGanhadorUF()
            {
                var entity = new LotofacilGanhadorUF(
                        this.UF,
                        this.Municipio,
                        this.Ganhadores
                    );
    
                return entity;
        }
    }
}
