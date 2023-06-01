using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClimateChangeEducation.Common.Enums.Enums;

namespace ClimateChangeEducation.Domain.Entities
{
    public class CourseEnrollment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime EnrollmentDate { get; set; }   
        public bool IsCompleted { get; set; }                  
        public Student? Student { get; set; }        
        public Course? CourseId { get; set; }
    }   
}
