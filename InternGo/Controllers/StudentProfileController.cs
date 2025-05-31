using InternGo.Application.Students;
using InternGo.Application.Students.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InternGo.WebAPI.Controllers.Student
{
    [Authorize(Roles = "Student")]
    [ApiController]
    [Route("api/student/profile")]
    public class StudentProfileController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentProfileController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateStudentProfileRequest request)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _studentService.UpdateStudentProfileAsync(userId, request);
            return Ok(new { message = "Profile updated successfully." });
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var profile = await _studentService.GetStudentProfileAsync(userId);

            if (profile == null)
                return NotFound(new { message = "Student profile not found." });

            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromBody] CreateStudentProfileRequest request)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _studentService.CreateStudentProfileAsync(userId, request);
            return Ok(new { message = "Profile created successfully." });
        }


    }
}
