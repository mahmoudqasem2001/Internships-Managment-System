using InternGo.Application.AI.Common;

namespace InternGo.Application.AI
{
    public interface IAIRecommendationService
    {
        Task<List<RecommendedInternshipDto>> RecommendInternshipsAsync(Guid studentUserId);
    }
}
