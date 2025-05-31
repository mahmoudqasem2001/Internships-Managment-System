namespace InternGo.Application.Companies.Common
{
    public class CompanyProfileDto
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string WorkingHours { get; set; } = string.Empty;
        public int MaxTrainees { get; set; }
        public string Website { get; set; } = string.Empty;
    }
}
