using System.Linq.Expressions;

namespace generic_repository_pattern.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        //Task<T> GetByIdAsync(int id);
        void Add(T entity);
        Task<bool> SaveChangesAsync();
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
    }
}
