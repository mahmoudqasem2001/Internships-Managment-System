using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence.Repositories.Base;
using System.Linq;

public interface IStudentProfileRepository : IRepository<StudentProfile>
{
    IQueryable<StudentProfile> GetQueryable();
}
