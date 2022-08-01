using System.Linq.Expressions;

namespace generic_repository_pattern.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllByConditionAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(string username);
        void Add(T entity);
        Task<bool> SaveChangesAsync();
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
    }
}
