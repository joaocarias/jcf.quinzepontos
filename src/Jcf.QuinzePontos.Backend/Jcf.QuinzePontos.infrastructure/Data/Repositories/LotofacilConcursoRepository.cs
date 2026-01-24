using Jcf.QuinzePontos.Domain.Entities;
using Jcf.QuinzePontos.Domain.Interfaces.Repositories;
using Jcf.QuinzePontos.Infrastructure.Data.Contexts;

namespace Jcf.QuinzePontos.Infrastructure.Data.Repositories
{
    public class LotofacilConcursoRepository : LotoFacilRepositoryBase<LotofacilConcurso>, ILotofacilConcursoRepository
    {
        public LotofacilConcursoRepository(AppDbContext context) : base(context)
        {

        }
    }
}
