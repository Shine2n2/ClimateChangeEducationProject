using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClimateChangeEducation.Domain.Entities
{
    public class CourseEnrollment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime EnrollmentDate { get; set; }   
        public bool IsCompleted { get; set; }    
        public string? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student? Student { get; set; }
        public string? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course? Course { get; set; }
    }   
}
