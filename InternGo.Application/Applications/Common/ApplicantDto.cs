namespace InternGo.Application.Applications.Common
{
    public class ApplicantDto
    {
        public Guid ApplicationId { get; set; }
        public string StudentFullName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime AppliedAt { get; set; }
    }
}
