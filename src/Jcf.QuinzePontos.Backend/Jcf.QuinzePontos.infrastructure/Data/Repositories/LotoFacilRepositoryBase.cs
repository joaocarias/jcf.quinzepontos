using Dapper;
using Jcf.QuinzePontos.Domain.Interfaces.Repositories;
using Jcf.QuinzePontos.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Jcf.QuinzePontos.Infrastructure.Data.Repositories
{
    public class LotoFacilRepositoryBase<T> : ILotoFacilRepositoryBase<T>
        where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly AppDapperContext _appDapperContext;
        protected readonly DbSet<T> _dbSet;
        protected readonly ILogger<T> _logger;

        public LotoFacilRepositoryBase(ILogger<T> logger, AppDbContext context, AppDapperContext appDapperContext)
        {
            _context = context;
            _appDapperContext = appDapperContext;
            _dbSet = _context.Set<T>();
            _logger = logger;
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T?> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        private protected async Task<TResult> ExecuteQueryAsync<TResult>(
            string query,
            Func<SqlMapper.GridReader, Task<TResult>> map)
        {
            using var multi = await _appDapperContext.Connection
                .QueryMultipleAsync(query);

            return await map(multi);
        }
    }
}
