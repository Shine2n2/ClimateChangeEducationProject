using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class TeacherRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhotoUrl { get; set; }
        public string Email { get; set; }
        public string FieldOfStudy { get; set; }
        public string SchoolCode { get; set; }
    }
}
