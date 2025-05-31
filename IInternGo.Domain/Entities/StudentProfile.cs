
using static System.Net.Mime.MediaTypeNames;

namespace InternGo.Domain.Entities
{
    public class StudentProfile
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

       public string Experience { get; set; }
    public string Skills { get; set; }
    public string ProgrammingLanguages { get; set; }
    public string CoverLetter { get; set; }
        public string? PreferredLocation { get; set; } 
        public string? Phone { get; set; }

        // AI recommendations
        public ICollection<AIRecommendation> AIRecommendations { get; set; }

        // Applications
        public ICollection<InternshipApplication> Applications { get; set; }

        // Reviews
        public ICollection<Review> Reviews { get; set; }
    }

}
