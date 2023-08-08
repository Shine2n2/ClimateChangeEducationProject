using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class QuizEnrollment
    {
        [Key]
        public string EnrollmentID { get; set; } = Guid.NewGuid().ToString();                      
        public DateTime QuizStartDate { get; set; }
        public short QuizScore { get; set; }
        public string Remark { get; set; }
        public bool IsCompleted { get; set; }
        public string? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student? Student { get; set; }
        public string? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course? Course { get; set; }
        public string? QuizId { get; set; }
        [ForeignKey("QuizId")]
        public virtual Quiz? Quiz { get; set; }
    }   
}
