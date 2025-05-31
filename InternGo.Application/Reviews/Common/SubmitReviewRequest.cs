namespace InternGo.Application.Reviews.Common
{
    public class SubmitReviewRequest
    {
        public Guid InternshipId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; } // 1 to 5
    }
}
