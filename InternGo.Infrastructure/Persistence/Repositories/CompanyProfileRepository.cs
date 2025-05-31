using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence.Repositories;
using InternGo.Infrastructure.Persistence.DbContexts;
using InternGo.Infrastructure.Persistence.Repositories.Base;

namespace InternGo.Infrastructure.Persistence.Repositories
{
    public class CompanyProfileRepository : Repository<CompanyProfile>, ICompanyProfileRepository
    {
        public CompanyProfileRepository(InternGoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
