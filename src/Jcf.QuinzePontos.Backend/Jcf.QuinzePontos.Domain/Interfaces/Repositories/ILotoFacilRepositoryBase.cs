using Dapper;

namespace Jcf.QuinzePontos.Domain.Interfaces.Repositories
{
    public interface ILotoFacilRepositoryBase<T> where T : class
    {
        Task<T?> GetByIdAsync(long id);
        Task<T?> CreateAsync(T entity);
        Task<IEnumerable<T>?> GetAllAsync();
        Task<T?> Update(T entity);
        Task<bool> Delete(T entity);

    }
}
