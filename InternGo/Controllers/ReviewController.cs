using InternGo.Application.Reviews;
using InternGo.Application.Reviews.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InternGo.WebAPI.Controllers.Student
{
    [Authorize(Roles = "Student")]
    [ApiController]
    [Route("api/student/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitReview([FromBody] SubmitReviewRequest request)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _reviewService.SubmitReviewAsync(userId, request);
            return Ok(new { message = "Review submitted." });
        }

        [AllowAnonymous]
        [HttpGet("{internshipId:guid}")]
        public async Task<IActionResult> GetReviews(Guid internshipId)
        {
            var reviews = await _reviewService.GetReviewsForInternshipAsync(internshipId);
            return Ok(reviews);
        }
    }
}
