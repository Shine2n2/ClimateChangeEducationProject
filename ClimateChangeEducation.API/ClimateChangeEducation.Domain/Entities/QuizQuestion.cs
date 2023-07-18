using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class QuizQuestion
    {
        [Key]
        public string QuizQuestionId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Text { get; set; }
        public string? MediaUrl { get; set; }
        public string QuizId { get; set; }
        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }        
        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }        
    }
}
