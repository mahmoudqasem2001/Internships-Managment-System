using InternGo.Application.Reviews.Common;

namespace InternGo.Application.Reviews
{
    public interface IReviewService
    {
        Task SubmitReviewAsync(Guid studentUserId, SubmitReviewRequest request);
        Task<List<ReviewDto>> GetReviewsForInternshipAsync(Guid internshipId);
        Task<List<ReviewDto>> GetReviewsForCompanyInternshipAsync(Guid companyUserId, Guid internshipId);

    }
}
