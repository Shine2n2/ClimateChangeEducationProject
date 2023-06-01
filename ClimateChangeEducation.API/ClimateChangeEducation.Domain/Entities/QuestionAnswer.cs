using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int? AllocatedScore { get; set; }
        public bool IsCorrect { get; set; }
        public QuizQuestion QuizQuestion { get; set; }        
    }
}
