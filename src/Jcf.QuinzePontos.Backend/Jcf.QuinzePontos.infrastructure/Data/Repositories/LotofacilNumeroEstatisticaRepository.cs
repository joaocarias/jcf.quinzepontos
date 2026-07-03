using Jcf.QuinzePontos.Domain.Entities;
using Jcf.QuinzePontos.Domain.Interfaces.Repositories;
using Jcf.QuinzePontos.Infrastructure.Data.Contexts;
using Microsoft.Extensions.Logging;

namespace Jcf.QuinzePontos.Infrastructure.Data.Repositories
{
    public class LotofacilNumeroEstatisticaRepository : LotoFacilRepositoryBase<LotofacilNumeroEstatistica>, ILotofacilNumeroEstatisticaRepository
    {
        public LotofacilNumeroEstatisticaRepository(ILogger<LotofacilNumeroEstatistica> logger, AppDbContext context, AppDapperContext dapperContext)
                : base(logger, context, dapperContext)
        {

        }
    }
}
