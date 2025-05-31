using InternGo.Application.Applications;
using InternGo.Application.Applications.Common;
using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InternGo.Infrastructure.Applications
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> ApplyAsync(Guid studentUserId, ApplyRequest request)
        {
            var studentProfile = await _unitOfWork.StudentProfiles
                .FirstOrDefaultAsync(sp => sp.UserId == studentUserId);

            if (studentProfile == null)
                throw new Exception("Student profile not found.");

            var alreadyApplied = await _unitOfWork.Applications
                .FirstOrDefaultAsync(a => a.StudentProfileId == studentProfile.Id && a.InternshipId == request.InternshipId);

            if (alreadyApplied != null)
                throw new Exception("Already applied to this internship.");

            var application = new InternshipApplication
            {
                Id = Guid.NewGuid(),
                StudentProfileId = studentProfile.Id,
                InternshipId = request.InternshipId,
                Status = "Pending",
                AppliedAt = DateTime.UtcNow
            };

            await _unitOfWork.Applications.AddAsync(application);
            await _unitOfWork.SaveChangesAsync();

            return application.Id;
        }
        public async Task<string> GetApplicationStatusAsync(Guid studentUserId, Guid applicationId)
        {
            var application = await _unitOfWork.Applications
                .Where(a => a.Id == applicationId && a.StudentProfile.UserId == studentUserId)
                .FirstOrDefaultAsync();

            if (application == null)
                throw new Exception("Application not found or access denied.");

            return application.Status;
        }


        public async Task<List<ApplicationDto>> GetMyApplicationsAsync(Guid studentUserId)
        {
            var applications = await _unitOfWork.Applications
                .Where(a => a.StudentProfile.UserId == studentUserId)
                .Include(a => a.Internship)
                .Select(a => new ApplicationDto
                {
                    ApplicationId = a.Id,
                    InternshipTitle = a.Internship.Title,
                    AppliedAt = a.AppliedAt,
                    Status = a.Status
                })
                .ToListAsync();

            return applications;
        }
    }
}
