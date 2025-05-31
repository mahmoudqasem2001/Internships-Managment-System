using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternGo.Domain.Entities
{
    public class CompanyProfile
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public int MaxTrainees { get; set; }       
        public string WorkingHours { get; set; }
        public ICollection<Internship> Internships { get; set; }
    }

}
