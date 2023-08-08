using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class Quiz
    {
        [Key]
        public string QuizId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course? Course { get; set; }
        public ICollection<QuizEnrollment> QuizEnrollment { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
