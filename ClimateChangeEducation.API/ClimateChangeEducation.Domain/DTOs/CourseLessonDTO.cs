using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class CourseLessonDTO
    {             
        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 150 characters!")]
        public string LessonName { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 150 characters!")]
        public string? LessonDescription { get; set; }
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 150 characters!")]
        public string LessonArticle { get; set; }
        public string? LessonVideoUrl { get; set; }
        public string? LessonPhotoUrl { get; set; }
        public int LessonDuration { get; set; }
        public CourseModule CourseModule { get; set; }
    }
}
