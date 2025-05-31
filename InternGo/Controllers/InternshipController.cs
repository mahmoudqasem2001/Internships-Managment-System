using InternGo.Application.Internships;
using InternGo.Application.Internships.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InternGo.Controllers
{
    [Authorize(Roles = "Company")]
    [ApiController]
    [Route("api/company/[controller]")]
    public class InternshipController : ControllerBase
    {
        private readonly IInternshipService _internshipService;

        public InternshipController(IInternshipService internshipService)
        {
            _internshipService = internshipService;
        }

        private Guid GetCurrentUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInternshipRequest request)
        {
            var internshipId = await _internshipService.CreateInternshipAsync(GetCurrentUserId(), request);
            return Ok(new { internshipId });
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateInternshipRequest request)
        {
            await _internshipService.UpdateInternshipAsync(GetCurrentUserId(), request);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _internshipService.DeleteInternshipAsync(GetCurrentUserId(), id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var internships = await _internshipService.GetCompanyInternshipsAsync(GetCurrentUserId());
            return Ok(internships);
        }
    }
}
