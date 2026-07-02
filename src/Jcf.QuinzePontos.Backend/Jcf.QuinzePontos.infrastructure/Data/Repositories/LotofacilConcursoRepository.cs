using Jcf.QuinzePontos.Domain.Entities;
using Jcf.QuinzePontos.Domain.Interfaces.Repositories;
using Jcf.QuinzePontos.infrastructure.Data.Queries.LotofacilConcurso;
using Jcf.QuinzePontos.Infrastructure.Data.Contexts;
using Microsoft.Extensions.Logging;

namespace Jcf.QuinzePontos.Infrastructure.Data.Repositories
{
    public class LotofacilConcursoRepository : LotoFacilRepositoryBase<LotofacilConcurso>, ILotofacilConcursoRepository
    {
        public LotofacilConcursoRepository(ILogger<LotofacilConcurso> logger, AppDbContext context, AppDapperContext dapperContext) 
                : base(logger, context, dapperContext)
        {

        }

        public async Task<LotofacilConcurso?> GetLastAsync()
        {           
            return await ExecuteQueryAsync(SqlGet._LAST_, async multi =>
            {
                var concurso = await multi.ReadFirstOrDefaultAsync<LotofacilConcurso>();
                if (concurso == null)
                    return null;

                var dezenas = await multi.ReadFirstOrDefaultAsync<LotofacilDezenas>();
                var rateios = (await multi.ReadAsync<LotofacilRateio>()).ToList();
                var ganhadores = (await multi.ReadAsync<LotofacilGanhadorUF>()).ToList();

                concurso.SetRelations(dezenas, rateios, ganhadores);

                return concurso;
            });            
        }

        public async Task<IEnumerable<LotofacilConcurso>> GetListAsync(int limit = 10, int start = 0)
        {
            try
            {
                return Enumerable.Empty<LotofacilConcurso>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<LotofacilConcurso>();
            }
        }
    }
}
