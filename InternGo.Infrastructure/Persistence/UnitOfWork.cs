using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence;
using InternGo.Domain.Interfaces.Persistence.Repositories;
using InternGo.Domain.Interfaces.Persistence.Repositories.Base;
using InternGo.Infrastructure.Persistence.DbContexts;
using InternGo.Infrastructure.Persistence.Repositories;
using InternGo.Infrastructure.Persistence.Repositories.Base;

namespace InternGo.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InternGoDbContext _dbContext;

        public UnitOfWork(InternGoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRepository Users => new UserRepository(_dbContext);
        public IInternshipRepository Internships => new InternshipRepository(_dbContext);
        public ICompanyProfileRepository CompanyProfiles => new CompanyProfileRepository(_dbContext);
        public IStudentProfileRepository StudentProfiles => new StudentProfileRepository(_dbContext);
        public IRepository<InternshipApplication> Applications => new Repository<InternshipApplication>(_dbContext);
        public IRepository<Review> Reviews => new Repository<Review>(_dbContext);

        public IRepository<AIRecommendation> AIRecommendations => new Repository<AIRecommendation>(_dbContext);

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.Database.CommitTransactionAsync(cancellationToken);
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.Database.RollbackTransactionAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
