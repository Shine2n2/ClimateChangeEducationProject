using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Student Student { get; set; }
        public Course Course { get; set; }       
        public Quiz Quiz { get; set; }
    }   
}
