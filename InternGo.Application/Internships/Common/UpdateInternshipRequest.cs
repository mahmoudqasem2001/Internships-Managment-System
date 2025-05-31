namespace InternGo.Application.Internships.Common
{
    public class UpdateInternshipRequest
    {
        public Guid InternshipId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? SkillsRequired { get; set; }
        public int? Capacity { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
