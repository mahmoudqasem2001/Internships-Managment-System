namespace InternGo.Application.Applications.Common
{
    public class ApplicationDto
    {
        public Guid ApplicationId { get; set; }
        public string InternshipTitle { get; set; } = string.Empty;
        public DateTime AppliedAt { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
