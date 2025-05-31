using InternGo.Application.Applications;
using InternGo.Application.Applications.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InternGo.WebAPI.Controllers.Student
{
    [Authorize(Roles = "Student")]
    [ApiController]
    [Route("api/student/[controller]")]
    public class StudentApplicationsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public StudentApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        private Guid GetCurrentUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }

        [HttpPost("apply")]
        public async Task<IActionResult> Apply([FromBody] ApplyRequest request)
        {
            var applicationId = await _applicationService.ApplyAsync(GetCurrentUserId(), request);
            return Ok(new { applicationId });
        }

        [HttpGet("my-applications")]
        public async Task<IActionResult> MyApplications()
        {
            var applications = await _applicationService.GetMyApplicationsAsync(GetCurrentUserId());
            return Ok(applications);
        }

        [HttpGet("status/{applicationId}")]
        public async Task<IActionResult> GetStatus(Guid applicationId)
        {
            var status = await _applicationService.GetApplicationStatusAsync(GetCurrentUserId(), applicationId);
            return Ok(new { applicationId, status });
        }


    }
}
