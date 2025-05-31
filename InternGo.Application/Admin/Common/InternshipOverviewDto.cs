namespace InternGo.Application.Admin.Common
{
    public class InternshipOverviewDto
    {
        public Guid InternshipId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public DateTime Deadline { get; set; }
    }
}
