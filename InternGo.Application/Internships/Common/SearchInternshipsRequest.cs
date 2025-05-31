namespace InternGo.Application.Internships.Common
{
    public class SearchInternshipsRequest
    {
        public string? Title { get; set; }
        public string? Skills { get; set; } // comma-separated
        public string? Location { get; set; }
        public DateTime? DeadlineBefore { get; set; }
    }
}
