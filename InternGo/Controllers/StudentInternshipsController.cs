using InternGo.Application.Internships;
using InternGo.Application.Internships.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternGo.WebAPI.Controllers.Student
{
    [Authorize(Roles = "Student")]
    [ApiController]
    [Route("api/student/[controller]")]
    public class StudentInternshipsController : ControllerBase
    {
        private readonly IInternshipService _internshipService;

        public StudentInternshipsController(IInternshipService internshipService)
        {
            _internshipService = internshipService;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchInternships([FromBody] SearchInternshipsRequest request)
        {
            var results = await _internshipService.SearchInternshipsAsync(request);
            return Ok(results);
        }
    }
}
