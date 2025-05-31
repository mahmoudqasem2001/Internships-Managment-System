using InternGo.Application.Reviews;
using InternGo.Application.Reviews.Common;
using InternGo.Domain.Entities;
using InternGo.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InternGo.Infrastructure.Reviews
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SubmitReviewAsync(Guid studentUserId, SubmitReviewRequest request)
        {
            var studentProfile = await _unitOfWork.StudentProfiles
                .FirstOrDefaultAsync(sp => sp.UserId == studentUserId);

            if (studentProfile == null)
                throw new Exception("Student profile not found.");

            var existing = await _unitOfWork.Reviews.FirstOrDefaultAsync(r =>
                r.StudentProfileId == studentProfile.Id && r.InternshipId == request.InternshipId);

            if (existing != null)
                throw new Exception("You already submitted a review for this internship.");

            var review = new Review
            {
                Id = Guid.NewGuid(),
                StudentProfileId = studentProfile.Id,
                InternshipId = request.InternshipId,
                Comment = request.Comment,
                Rating = request.Rating,
                PostedAt = DateTime.UtcNow
            };

            await _unitOfWork.Reviews.AddAsync(review);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ReviewDto>> GetReviewsForInternshipAsync(Guid internshipId)
        {
            var reviews = await _unitOfWork.Reviews
                .Where(r => r.InternshipId == internshipId)
                .Include(r => r.StudentProfile)
                    .ThenInclude(sp => sp.User)
                .Select(r => new ReviewDto
                {
                    StudentName = r.StudentProfile.User.FullName,
                    Comment = r.Comment,
                    Rating = r.Rating,
                    PostedAt = r.PostedAt
                })
                .ToListAsync();

            return reviews;
        }
        public async Task<List<ReviewDto>> GetReviewsForCompanyInternshipAsync(Guid companyUserId, Guid internshipId)
        {
            var internship = await _unitOfWork.Internships
      .GetQueryable()
      .Include(i => i.CompanyProfile)
      .FirstOrDefaultAsync(i => i.Id == internshipId && i.CompanyProfile.UserId == companyUserId);


            if (internship == null)
                throw new Exception("Unauthorized or internship not found.");

            var reviews = await _unitOfWork.Reviews
                .Where(r => r.InternshipId == internshipId)
                .Include(r => r.StudentProfile)
                    .ThenInclude(sp => sp.User)
                .Select(r => new ReviewDto
                {
                    StudentName = r.StudentProfile.User.FullName,
                    Comment = r.Comment,
                    Rating = r.Rating,
                    PostedAt = r.PostedAt
                })
                .ToListAsync();

            return reviews;
        }

    }
}
