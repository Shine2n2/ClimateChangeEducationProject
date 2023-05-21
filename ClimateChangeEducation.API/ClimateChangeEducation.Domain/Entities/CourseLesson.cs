using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class CourseLesson
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonDescription { get; set; }
        public string? LessonArticle { get; set; }
        public string? LessonVideoUrl { get; set; }
        public string? LessonPhotoUrl { get; set; }
        public int LessonDuration { get; set; }
    }
}
