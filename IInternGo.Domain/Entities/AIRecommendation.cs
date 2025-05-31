

namespace InternGo.Domain.Entities
{
    public class AIRecommendation
    {
        public Guid Id { get; set; }
        public Guid StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }

        public Guid InternshipId { get; set; }
        public Internship Internship { get; set; }

        public double MatchScore { get; set; } // 0.0 - 1.0
        public DateTime RecommendedAt { get; set; } = DateTime.UtcNow;
    }

}
