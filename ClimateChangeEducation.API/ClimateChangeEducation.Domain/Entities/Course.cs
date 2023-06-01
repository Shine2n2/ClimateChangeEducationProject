using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class Course
    {
        [Key]
        public string CourseId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string CourseTitle { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 150 characters!")]
        public string? CourseDescription { get; set; }
        public DateTime CourseStartDateTime { get; set; }
        public DateTime CourseEndDateTime { get; set; }     
        public bool IsEnrolled { get; set; }     
        public Quiz? Quiz { get; set; }        
        public ICollection<CourseModule> CourseModules { get; set; }
        public ICollection<CourseEnrollment>? CourseEnrollments { get; set; }     
    }
}
