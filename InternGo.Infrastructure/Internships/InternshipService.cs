using InternGo.Application.Internships;
using InternGo.Application.Internships.Common;
using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence;
using InternGo.Domain.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InternGo.Infrastructure.Internships
{
    public class InternshipService : IInternshipService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InternshipService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateInternshipAsync(Guid companyUserId, CreateInternshipRequest request)
        {
            var companyProfile = await _unitOfWork.CompanyProfiles.FirstOrDefaultAsync(c => c.UserId == companyUserId);

            if (companyProfile == null)
                throw new Exception("Company profile not found.");

            var internship = new Internship
            {
                Id = Guid.NewGuid(),
                CompanyProfileId = companyProfile.Id,
                Title = request.Title,
                Description = request.Description,
                SkillsRequired = request.SkillsRequired,
                Capacity = request.Capacity,
                Deadline = request.Deadline
            };

            await _unitOfWork.Internships.AddAsync(internship);
            await _unitOfWork.SaveChangesAsync();

            return internship.Id;
        }

        public async Task<bool> UpdateInternshipAsync(Guid companyUserId, UpdateInternshipRequest request)
        {
            var internship = await _unitOfWork.Internships
                .FirstOrDefaultAsync(i => i.Id == request.InternshipId && i.CompanyProfile.UserId == companyUserId);

            if (internship == null)
                throw new Exception("Internship not found or access denied.");

            internship.Title = request.Title ?? internship.Title;
            internship.Description = request.Description ?? internship.Description;
            internship.SkillsRequired = request.SkillsRequired ?? internship.SkillsRequired;
            internship.Capacity = request.Capacity ?? internship.Capacity;
            internship.Deadline = request.Deadline ?? internship.Deadline;

            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteInternshipAsync(Guid companyUserId, Guid internshipId)
        {
            var internship = await _unitOfWork.Internships
                .FirstOrDefaultAsync(i => i.Id == internshipId && i.CompanyProfile.UserId == companyUserId);

            if (internship == null)
                throw new Exception("Internship not found or access denied.");

            _unitOfWork.Internships.Delete(internship);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<InternshipDto>> SearchInternshipsAsync(SearchInternshipsRequest request)
        {
            var query = _unitOfWork.Internships
                .GetAll()
                .Include(i => i.CompanyProfile)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                query = query.Where(i => i.Title.Contains(request.Title));
            }

            if (!string.IsNullOrWhiteSpace(request.Skills))
            {
                var skillList = request.Skills.Split(',').Select(s => s.Trim().ToLower());
                query = query.Where(i => skillList.Any(skill => i.SkillsRequired.ToLower().Contains(skill)));
            }

            if (!string.IsNullOrWhiteSpace(request.Location))
            {
                query = query.Where(i => i.CompanyProfile.Location.Contains(request.Location));
            }

            if (request.DeadlineBefore.HasValue)
            {
                query = query.Where(i => i.Deadline <= request.DeadlineBefore.Value);
            }

            var result = await query
                .Select(i => new InternshipDto
                {
                    InternshipId = i.Id,
                    Title = i.Title,
                    Description = i.Description,
                    SkillsRequired = i.SkillsRequired,
                    Capacity = i.Capacity,
                    Deadline = i.Deadline
                })
                .ToListAsync();

            return result;
        }

        public async Task<List<InternshipDto>> GetCompanyInternshipsAsync(Guid companyUserId)
        {
            var internships = await _unitOfWork.Internships
                .Where(i => i.CompanyProfile.UserId == companyUserId)
                .Select(i => new InternshipDto
                {
                    InternshipId = i.Id,
                    Title = i.Title,
                    Description = i.Description,
                    SkillsRequired = i.SkillsRequired,
                    Capacity = i.Capacity,
                    Deadline = i.Deadline
                })
                .ToListAsync();

            return internships;
        }
    }
}
