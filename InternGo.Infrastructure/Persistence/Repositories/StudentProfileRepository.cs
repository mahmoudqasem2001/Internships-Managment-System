using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence.Repositories;
using InternGo.Infrastructure.Persistence.DbContexts;
using InternGo.Infrastructure.Persistence.Repositories.Base;

public class StudentProfileRepository : Repository<StudentProfile>, IStudentProfileRepository
{
    private readonly InternGoDbContext _context;

    public StudentProfileRepository(InternGoDbContext context) : base(context)
    {
        _context = context;
    }

    public IQueryable<StudentProfile> GetQueryable()
    {
        return _context.StudentProfiles;
    }
}
