using InternGo.Application.Applications;
using InternGo.Application.Applications.Common;
using InternGo.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InternGo.Infrastructure.Applications
{
    public class CompanyApplicationService : ICompanyApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> UpdateApplicationStatusAsync(Guid companyUserId, UpdateApplicationStatusRequest request)
        {
            var application = await _unitOfWork.Applications
                .Where(a => a.Id == request.ApplicationId)
                .Include(a => a.Internship)
                .ThenInclude(i => i.CompanyProfile)
                .FirstOrDefaultAsync();

            if (application == null || application.Internship.CompanyProfile.UserId != companyUserId)
                throw new Exception("Application not found or access denied.");

            if (request.Status != "Accepted" && request.Status != "Rejected")
                throw new Exception("Invalid status. Only 'Accepted' or 'Rejected' are allowed.");

            application.Status = request.Status;

            _unitOfWork.Applications.Update(application);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<List<ApplicantDto>> GetApplicantsForInternshipAsync(Guid companyUserId, Guid internshipId)
        {
            var internship = await _unitOfWork.Internships
                .FirstOrDefaultAsync(i => i.Id == internshipId && i.CompanyProfile.UserId == companyUserId);

            if (internship == null)
                throw new Exception("Internship not found or access denied.");

            var applicants = await _unitOfWork.Applications
                .Where(a => a.InternshipId == internshipId)
                .Include(a => a.StudentProfile)
                    .ThenInclude(sp => sp.User)
                .Select(a => new ApplicantDto
                {
                    ApplicationId = a.Id,
                    StudentFullName = a.StudentProfile.User.FullName,
                    Status = a.Status,
                    AppliedAt = a.AppliedAt
                })
                .ToListAsync();

            return applicants;
        }
    }
}
