using InternGo.Application.Admin;
using InternGo.Application.Admin.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternGo.WebAPI.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/admin/dashboard")]
    public class AdminDashboardController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminDashboardController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _adminService.GetAllUsersAsync();
            return Ok(result);
        }

        [HttpPut("users/{userId}/toggle")]
        public async Task<IActionResult> ToggleUserStatus(Guid userId)
        {
            await _adminService.ToggleUserStatusAsync(userId);
            return Ok(new { message = "User status updated successfully." });
        }


        [HttpGet("internships")]
        public async Task<IActionResult> GetAllInternships()
        {
            var result = await _adminService.GetAllInternshipsAsync();
            return Ok(result);
        }

        [HttpDelete("internships/{internshipId}")]
        public async Task<IActionResult> DeleteInternship(Guid internshipId)
        {
            await _adminService.DeleteInternshipAsync(internshipId);
            return Ok(new { message = "Internship deleted successfully." });
        }

        [HttpGet("applications")]
        public async Task<IActionResult> GetAllApplications()
        {
            var result = await _adminService.GetAllApplicationsAsync();
            return Ok(result);
        }

        [HttpDelete("reviews/{reviewId}")]
        public async Task<IActionResult> DeleteReview(Guid reviewId)
        {
            await _adminService.DeleteReviewAsync(reviewId);
            return Ok(new { message = "Review deleted successfully." });
        }
    }
}
