using InternGo.Application.AI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InternGo.WebAPI.Controllers.Student
{
    [Authorize(Roles = "Student")]
    [ApiController]
    [Route("api/student/recommendations")]
    public class AIRecommendationController : ControllerBase
    {
        private readonly IAIRecommendationService _aiService;

        public AIRecommendationController(IAIRecommendationService aiService)
        {
            _aiService = aiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecommendations()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var results = await _aiService.RecommendInternshipsAsync(userId);
            return Ok(results);
        }
    }
}
