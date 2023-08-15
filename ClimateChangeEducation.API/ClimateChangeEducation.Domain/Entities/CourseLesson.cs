using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class CourseLesson
    {
        [Key]
        public string LessonId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string LessonName { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 150 characters!")]
        public string? LessonDescription { get; set; }
        public string? LessonArticle { get; set; }
        public string? LessonVideoUrl { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public string? LessonPhotoUrl { get; set; }        
        public int LessonDuration { get; set; }   
        public string? ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public virtual CourseModule? CourseModule { get; set;}
    }
}
