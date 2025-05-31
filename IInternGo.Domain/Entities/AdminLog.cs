

namespace InternGo.Domain.Entities
{
    public class AdminLog
    {
        public Guid Id { get; set; }
        public Guid AdminUserId { get; set; }
        public User Admin { get; set; }

        public string Action { get; set; }
        public string TargetTable { get; set; }
        public Guid? TargetId { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

}
