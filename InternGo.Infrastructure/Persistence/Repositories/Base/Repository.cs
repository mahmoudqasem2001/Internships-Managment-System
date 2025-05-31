using InternGo.Domain.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using InternGo.Infrastructure.Persistence.DbContexts;
using InternGo.Domain.Interfaces.Persistence.Repositories.Base;

namespace InternGo.Infrastructure.Persistence.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly InternGoDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(InternGoDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();

        }

        public async Task<T?> GetByIdAsync(Guid id) => await _dbContext.Set<T>().FindAsync(id);

        public async Task<List<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();
        public IQueryable<T> GetAll() 
        {
            return _dbContext.Set<T>().AsQueryable();
        }


        public async Task AddAsync(T entity) => await _dbContext.Set<T>().AddAsync(entity);

        public void Update(T entity) => _dbContext.Set<T>().Update(entity);

        public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);

        public IQueryable<T> GetQueryable() => _dbSet.AsQueryable();

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbContext.Set<T>().Where(predicate);

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) =>
            await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
    }
}
