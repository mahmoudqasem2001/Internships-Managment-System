using System.Linq.Expressions;

namespace InternGo.Domain.Interfaces.Persistence.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        IQueryable<T> GetAll();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetQueryable();
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}
