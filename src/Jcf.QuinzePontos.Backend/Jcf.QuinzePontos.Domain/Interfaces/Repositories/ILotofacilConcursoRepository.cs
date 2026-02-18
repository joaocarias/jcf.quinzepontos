using Jcf.QuinzePontos.Domain.Entities;

namespace Jcf.QuinzePontos.Domain.Interfaces.Repositories
{
    public interface ILotofacilConcursoRepository : ILotoFacilRepositoryBase<LotofacilConcurso>
    {        
        Task<LotofacilConcurso?> GetLastAsync();
    }
}
