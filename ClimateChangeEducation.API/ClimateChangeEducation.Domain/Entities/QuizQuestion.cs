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
        public string Text { get; set; }
        public Quiz QuizId { get; set; }
        public Course CourseId { get; set; }    
        public ICollection<QuestionAnswer> Answers { get; set; }        
    }
}
