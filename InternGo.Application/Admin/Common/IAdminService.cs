using InternGo.Application.Admin.Common;

namespace InternGo.Application.Admin
{
    public interface IAdminService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task ToggleUserStatusAsync(Guid userId);

        Task<List<InternshipOverviewDto>> GetAllInternshipsAsync();
        Task DeleteInternshipAsync(Guid internshipId);

        Task<List<ApplicationOverviewDto>> GetAllApplicationsAsync();
        Task DeleteReviewAsync(Guid reviewId);
    }
}
