using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class School
    {
        public string SchoolId { get; set; } = Guid.NewGuid().ToString();
        public string SchoolCode { get; set; }
        public string SchoolName { get; set; }
        public string SchoolEmail { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
