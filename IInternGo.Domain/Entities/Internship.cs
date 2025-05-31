
using static System.Net.Mime.MediaTypeNames;

namespace InternGo.Domain.Entities
{
    public class Internship
    {
        public Guid Id { get; set; }
        public Guid CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string SkillsRequired { get; set; }
        public int Capacity { get; set; }
        public DateTime Deadline { get; set; }

        public ICollection<InternshipApplication> Applications { get; set; }
    }

}
