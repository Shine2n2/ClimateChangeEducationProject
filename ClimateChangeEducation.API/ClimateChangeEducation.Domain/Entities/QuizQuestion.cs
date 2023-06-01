using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class QuizQuestion
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Text { get; set; }
        public string? MediaUrl { get; set; }
        public Quiz Quiz { get; set; }        
        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }        
    }
}
