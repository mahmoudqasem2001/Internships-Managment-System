using InternGo.Application.Applications;
using InternGo.Application.Applications.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InternGo.WebAPI.Controllers.Company
{
    [Authorize(Roles = "Company")]
    [ApiController]
    [Route("api/company/[controller]")]
    public class CompanyApplicationsController : ControllerBase
    {
        private readonly ICompanyApplicationService _companyApplicationService;

        public CompanyApplicationsController(ICompanyApplicationService companyApplicationService)
        {
            _companyApplicationService = companyApplicationService;
        }

        private Guid GetCurrentUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }



        [HttpPost("update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateApplicationStatusRequest request)
        {
            await _companyApplicationService.UpdateApplicationStatusAsync(GetCurrentUserId(), request);
            return Ok(new { message = "Application status updated successfully." });
        }

        [HttpGet("internship/{internshipId}/applicants")]
        public async Task<IActionResult> GetApplicants(Guid internshipId)
        {
            var applicants = await _companyApplicationService.GetApplicantsForInternshipAsync(GetCurrentUserId(), internshipId);
            return Ok(applicants);
        }
    }
}
