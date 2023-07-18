using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class CourseModule
    {
        [Key]
        public string ModuleId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string ModuleName { get; set; }
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 150 characters!")]
        public string? ModuleDescription { get; set; }        
        public string? MediaUrl { get; set; }
        public string CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public ICollection<CourseLesson> Lessons { get; set; }
       
    }
}
