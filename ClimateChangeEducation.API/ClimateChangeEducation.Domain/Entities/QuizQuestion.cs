using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class QuizQuestion
    {
        
        public int Id { get; set; }
        public string Text { get; set; }
        public QuizQuestion QuizQuestionId { get; set; }
        public Course CourseId { get; set; }    
        public List<QuestionAnswer> Answers { get; set; }        
    }
}
