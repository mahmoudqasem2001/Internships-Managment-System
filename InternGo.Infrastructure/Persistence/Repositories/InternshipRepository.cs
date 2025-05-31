using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence.Repositories;
using InternGo.Infrastructure.Persistence.DbContexts;
using InternGo.Infrastructure.Persistence.Repositories.Base;

namespace InternGo.Infrastructure.Persistence.Repositories
{
    public class InternshipRepository : Repository<Internship>, IInternshipRepository
    {
        private readonly InternGoDbContext _context;

        public InternshipRepository(InternGoDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Internship> GetQueryable()
        {
            return _context.Internships;
        }
    }
}
