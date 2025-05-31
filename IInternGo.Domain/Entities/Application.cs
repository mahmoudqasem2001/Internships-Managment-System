
namespace InternGo.Domain.Entities
{
    public class InternshipApplication
    {
        public Guid Id { get; set; }
        public Guid StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }

        public Guid InternshipId { get; set; }
        public Internship Internship { get; set; }

        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";
    }

}
