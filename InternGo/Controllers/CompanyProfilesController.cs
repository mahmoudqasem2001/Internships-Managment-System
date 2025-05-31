using InternGo.Application.Companies;
using InternGo.Application.Companies.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternGo.WebAPI.Controllers.Student
{
    [Authorize(Roles = "Student")]
    [ApiController]
    [Route("api/student/companies")]
    public class CompanyProfilesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyProfilesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("{companyId:guid}")]
        public async Task<IActionResult> GetCompanyProfile(Guid companyId)
        {
            var profile = await _companyService.GetCompanyProfileAsync(companyId);
            if (profile == null)
                return NotFound();

            return Ok(profile);
        }
    }
}
