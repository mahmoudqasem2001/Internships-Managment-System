using InternGo.Application.Admin;
using InternGo.Application.Admin.Common;
using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InternGo.Infrastructure.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Users
                .GetAll()
                .Select(u => new UserDto
                {
                    UserId = u.Id,
                    FullName = u.FullName,
                    Email = u.Email,
                    Role = u.Role.ToString(),
                    IsActive = u.IsActive
                })
                .ToListAsync();

            return users;
        }

        public async Task ToggleUserStatusAsync(Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            user.IsActive = !user.IsActive;
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<List<InternshipOverviewDto>> GetAllInternshipsAsync()
        {
            var internships = await _unitOfWork.Internships
                .GetAll()
                .Include(i => i.CompanyProfile)
                .Select(i => new InternshipOverviewDto
                {
                    InternshipId = i.Id,
                    Title = i.Title,
                    CompanyName = i.CompanyProfile.CompanyName,
                    Capacity = i.Capacity,
                    Deadline = i.Deadline
                })
                .ToListAsync();

            return internships;
        }

        public async Task DeleteInternshipAsync(Guid internshipId)
        {
            var internship = await _unitOfWork.Internships.GetByIdAsync(internshipId);
            if (internship == null)
                throw new Exception("Internship not found");

            _unitOfWork.Internships.Delete(internship);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ApplicationOverviewDto>> GetAllApplicationsAsync()
        {
            var applications = await _unitOfWork.Applications
                .GetAll()
                .Include(a => a.StudentProfile)
                    .ThenInclude(sp => sp.User)
                .Include(a => a.Internship)
                .Select(a => new ApplicationOverviewDto
                {
                    ApplicationId = a.Id,
                    StudentFullName = a.StudentProfile.User.FullName,
                    InternshipTitle = a.Internship.Title,
                    Status = a.Status,
                    AppliedAt = a.AppliedAt
                })
                .ToListAsync();

            return applications;
        }

        public async Task DeleteReviewAsync(Guid reviewId)
        {
            var review = await _unitOfWork.Reviews.GetByIdAsync(reviewId);
            if (review == null)
                throw new Exception("Review not found");

            _unitOfWork.Reviews.Delete(review);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
