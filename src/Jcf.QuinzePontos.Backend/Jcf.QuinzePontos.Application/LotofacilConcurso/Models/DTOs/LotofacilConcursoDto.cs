using Jcf.QuinzePontos.infrastructure.Extensions;
using Jcf.QuinzePontos.Infrastructure.Extensions;

namespace Jcf.QuinzePontos.Application.LotofacilConcurso.Models.DTOs
{
    public class LotofacilConcursoDTO
    {        
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

        public Domain.Entities.LotofacilConcurso ToLotofacilConcurso()
        {
            var entity = new Domain.Entities.LotofacilConcurso(
                    this.Numero,
                    this.DataApuracao?.DatePtBrToDateTime().GetValueOrDefault().ToUtcKind() ?? DateTime.MinValue,
                    this.DataProximoConcurso?.DatePtBrToDateTime().GetValueOrDefault().ToUtcKind() ?? DateTime.MinValue,
                    this.Acumulado,
                    this.UltimoConcurso,
                    this.LocalSorteio,
                    this.NomeMunicipioUFSorteio,
                    this.Observacao,
                    this.ValorArrecadado,
                    this.ValorEstimadoProximoConcurso,
                    this.ValorAcumuladoProximoConcurso,
                    this.ValorAcumuladoProximoConcurso,
                    this.ListaDezenas.Any() ? ListaDezenas.ListIntToDeLotofacilDezenas() : null,
                    [.. this.ListaRateioPremio.Select(x => x.ToLotofacilRateio())],
                    [.. this.ListaMunicipioUFGanhadores.Select(x => x.ToLotofacilGanhadorUF())]
                );
            return entity;
        }
    }
}
