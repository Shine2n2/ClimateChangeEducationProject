using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class CourseModule
    {
        [Key]
        public string ModuleId { get; set; } = Guid.NewGuid().ToString();
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public ICollection<CourseLesson> Lessons { get; set; }
    }
}
