using Jcf.QuinzePontos.Domain.Entities;
using System.Reflection.Metadata;

namespace Jcf.QuinzePontos.Domain.Interfaces.Repositories
{
    public interface ILotofacilConcursoRepository : ILotoFacilRepositoryBase<LotofacilConcurso>
    {        
        Task<LotofacilConcurso?> GetLastAsync();
        Task<IEnumerable<LotofacilConcurso>> GetListAsync(int limit = 10, int start = 0);
    }
}
