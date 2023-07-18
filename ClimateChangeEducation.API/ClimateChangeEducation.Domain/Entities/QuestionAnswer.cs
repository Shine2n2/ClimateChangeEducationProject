using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class QuestionAnswer
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Text { get; set; }
        public short AllocatedScore { get; set; } = 0;
        public bool IsCorrect { get; set; }
        public string QuizQuestionId { get; set; }
        [ForeignKey("QuizQuestionId")]
        public virtual  QuizQuestion QuizQuestion { get; set; }        
    }
}
