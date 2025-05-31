using InternGo.Application.Applications.Common;

namespace InternGo.Application.Applications
{
    public interface ICompanyApplicationService
    {
        Task<List<ApplicantDto>> GetApplicantsForInternshipAsync(Guid companyUserId, Guid internshipId);
        Task<bool> UpdateApplicationStatusAsync(Guid companyUserId, UpdateApplicationStatusRequest request);

    }
}
