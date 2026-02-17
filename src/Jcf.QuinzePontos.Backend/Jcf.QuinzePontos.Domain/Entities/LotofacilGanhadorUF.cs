using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.QuinzePontos.Domain.Entities
{
    public class LotofacilGanhadorUF : EntityBase
    {
        public LotofacilGanhadorUF(string uF, string municipio, int ganhadores)
        {
            UF = uF;
            Municipio = municipio;
            Ganhadores = ganhadores;
        }

        public LotofacilGanhadorUF() { }

        public long? LotofacilConcursoId { get; private set; }

        [ForeignKey(nameof(LotofacilConcursoId))]
        public LotofacilConcurso? LotofacilConcurso { get; private set; }

        public string? UF { get; set; }
        public string? Municipio { get; set; }
        public int? Ganhadores { get; set; }        
    }
}
