namespace InternGo.Application.Internships.Common
{
    public class InternshipDto
    {
        public Guid InternshipId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SkillsRequired { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public DateTime Deadline { get; set; }
    }
}
