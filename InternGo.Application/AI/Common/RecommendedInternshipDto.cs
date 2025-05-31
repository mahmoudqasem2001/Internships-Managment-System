namespace InternGo.Application.AI.Common
{
    public class RecommendedInternshipDto
    {
        public Guid InternshipId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public double MatchScore { get; set; }
    }
}
