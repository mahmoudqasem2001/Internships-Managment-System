using InternGo.Domain.Entities;

namespace InternGo.Domain.Interfaces.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);
        Task AddAsync(User user);

        IQueryable<User?> GetAll();
    }
}
