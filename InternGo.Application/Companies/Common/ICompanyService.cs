

namespace InternGo.Application.Companies.Common
{
    public interface ICompanyService
    {
        Task<CompanyProfileDto?> GetCompanyProfileAsync(Guid companyProfileId);

    }
}
