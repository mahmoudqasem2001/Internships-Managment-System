using InternGo.Domain.Enums;

namespace InternGo.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public StudentProfile StudentProfile { get; set; }
        public CompanyProfile CompanyProfile { get; set; }
        public ICollection<AdminLog> AdminLogs { get; set; }
    }

}
