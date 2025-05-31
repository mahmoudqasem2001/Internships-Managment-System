namespace InternGo.Application.Admin.Common
{
    public class ApplicationOverviewDto
    {
        public Guid ApplicationId { get; set; }
        public string StudentFullName { get; set; } = string.Empty;
        public string InternshipTitle { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime AppliedAt { get; set; }
    }
}
