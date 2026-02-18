using Jcf.QuinzePontos.Domain.Entities;
using Jcf.QuinzePontos.Domain.Interfaces.Repositories;
using Jcf.QuinzePontos.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jcf.QuinzePontos.Infrastructure.Data.Repositories
{
    public class LotofacilConcursoRepository : LotoFacilRepositoryBase<LotofacilConcurso>, ILotofacilConcursoRepository
    {
        public LotofacilConcursoRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<LotofacilConcurso?> GetLastAsync()
        {
            return await _context.Concursos
                                    .Include(x => x.Dezenas)
                                    .Include(x => x.GanhadoresUF)
                                    .Include(x => x.Rateios)
                                    .AsNoTracking()
                                    .OrderByDescending(c => c.Numero)
                                    .FirstOrDefaultAsync();
        }
    }
}
