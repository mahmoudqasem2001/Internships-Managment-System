using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence.Repositories;
using InternGo.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace InternGo.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly InternGoDbContext _dbContext;

        public UserRepository(InternGoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public IQueryable<User?> GetAll()
        {
            return _dbContext.Set<User>().AsQueryable();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
