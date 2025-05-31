using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence.Repositories;
using InternGo.Domain.Interfaces.Persistence.Repositories.Base;
using static System.Net.Mime.MediaTypeNames;

namespace InternGo.Domain.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IInternshipRepository Internships { get; }
        ICompanyProfileRepository CompanyProfiles { get; }
        IStudentProfileRepository StudentProfiles { get; }
        IRepository<InternshipApplication> Applications { get; }
        IRepository<AIRecommendation> AIRecommendations { get; }

        IRepository<Review> Reviews { get; }
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
