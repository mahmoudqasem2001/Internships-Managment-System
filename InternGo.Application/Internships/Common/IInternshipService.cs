namespace InternGo.Application.Internships.Common
{
    public interface IInternshipService
    {
        Task<Guid> CreateInternshipAsync(Guid companyUserId, CreateInternshipRequest request);
        Task<bool> UpdateInternshipAsync(Guid companyUserId, UpdateInternshipRequest request);
        Task<bool> DeleteInternshipAsync(Guid companyUserId, Guid internshipId);
        Task<List<InternshipDto>> GetCompanyInternshipsAsync(Guid companyUserId);
        Task<List<InternshipDto>> SearchInternshipsAsync(SearchInternshipsRequest request);

    }
}
