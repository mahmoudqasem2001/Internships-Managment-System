namespace InternGo.Application.Reviews.Common
{
    public class ReviewDto
    {
        public string StudentName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime PostedAt { get; set; }
    }
}
