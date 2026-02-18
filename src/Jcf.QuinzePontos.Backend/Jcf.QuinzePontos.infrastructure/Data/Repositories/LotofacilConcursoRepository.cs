using Dapper;
using Jcf.QuinzePontos.Domain.Entities;
using Jcf.QuinzePontos.Domain.Interfaces.Repositories;
using Jcf.QuinzePontos.infrastructure.Data.Queries.LotofacilConcurso;
using Jcf.QuinzePontos.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Jcf.QuinzePontos.Infrastructure.Data.Repositories
{
    public class LotofacilConcursoRepository : LotoFacilRepositoryBase<LotofacilConcurso>, ILotofacilConcursoRepository
    {
        public LotofacilConcursoRepository(AppDbContext context, AppDapperContext dapperContext) : base(context, dapperContext)
        {

        }

        public async Task<LotofacilConcurso?> GetLastAsync()
        {           
            using var multi = await _appDapperContext.Connection.QueryMultipleAsync(SqlGet._LAST_);

            var concurso = await multi.ReadFirstOrDefaultAsync<LotofacilConcurso>();
            if (concurso == null)
                return null;

            var dezenas = await multi.ReadFirstOrDefaultAsync<LotofacilDezenas>();
            var rateios = (await multi.ReadAsync<LotofacilRateio>()).ToList();
            var ganhadores = (await multi.ReadAsync<LotofacilGanhadorUF>()).ToList();

            concurso.SetRelations(dezenas, rateios, ganhadores);

            return concurso;
        }
    }
}
