using InternGo.Application.Companies;
using InternGo.Application.Companies.Common;
using InternGo.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InternGo.Infrastructure.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyProfileDto?> GetCompanyProfileAsync(Guid companyProfileId)
        {
            var company = await _unitOfWork.CompanyProfiles
                .Where(c => c.Id == companyProfileId)
                .Select(c => new CompanyProfileDto
                {
                    CompanyId = c.Id,
                    CompanyName = c.CompanyName,
                    Location = c.Location,
                    WorkingHours = c.WorkingHours,
                    MaxTrainees = c.MaxTrainees,
                    Website = c.Website
                })
                .FirstOrDefaultAsync();

            return company;
        }
    }
}
