using FinalCaseForPapara.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace FinalCaseForPapara.DataAccess.Repositories.GenericRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly PaparaDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(PaparaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
