

namespace InternGo.Domain.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }

        public Guid InternshipId { get; set; }
        public Internship Internship { get; set; }

        public string Comment { get; set; }
        public int Rating { get; set; } // 1-5
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
    }

}
