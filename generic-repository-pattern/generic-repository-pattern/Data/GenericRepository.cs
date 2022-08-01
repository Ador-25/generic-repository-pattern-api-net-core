using generic_repository_pattern.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace generic_repository_pattern.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities
                .Where(predicate)
                .ToListAsync();
        }

        // Since no base, No Id
        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<T> GetByIdAsync(string username)
        {
            return await _entities.FindAsync(username);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }
    }
}
