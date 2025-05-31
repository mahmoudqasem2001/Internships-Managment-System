namespace InternGo.Application.Applications.Common
{
    public class UpdateApplicationStatusRequest
    {
        public Guid ApplicationId { get; set; }
        public string Status { get; set; } = string.Empty; // Expected values: "Accepted" or "Rejected"
    }
}
