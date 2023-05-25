using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class CourseLesson
    {
        [Key]
        public string LessonId { get; set; } = Guid.NewGuid().ToString();
        public string LessonName { get; set; }
        public string LessonDescription { get; set; }
        public string? LessonArticle { get; set; }
        public string? LessonVideoUrl { get; set; }
        public string? LessonPhotoUrl { get; set; }
        public int LessonDuration { get; set; }
        public Course CourseId { get; set;}
    }
}
