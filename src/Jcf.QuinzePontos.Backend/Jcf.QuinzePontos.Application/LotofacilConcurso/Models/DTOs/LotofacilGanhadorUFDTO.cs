using Jcf.QuinzePontos.Application.Common.DTOs;

namespace Jcf.QuinzePontos.Application.LotofacilConcurso.Models.DTOs
{
    public class LotofacilGanhadorUFDTO 
    {       
        public string UF { get; set; } = string.Empty;
        public string Municipio { get; set; } = string.Empty;
        public int Ganhadores { get; set; }
    }
}
