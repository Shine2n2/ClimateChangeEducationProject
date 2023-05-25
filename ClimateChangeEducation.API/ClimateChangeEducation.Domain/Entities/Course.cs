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
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public DateTime CourseStartDateTime { get; set; }
        public DateTime CourseEndDateTime { get; set; }     
        public Quiz QuizId { get; set; }
        public ICollection<CourseModule> Modules { get; set; }
        //public List<Instructor> Instructors { get; set; }
    }
}
