using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public DateTime CourseStartDateTime { get; set; }
        public DateTime CourseEndDateTime { get; set; }
        
        public List<CourseModule> Modules { get; set; }
        //public List<Instructor> Instructors { get; set; }
    }
}
