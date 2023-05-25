using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class QuizResult
    {
        public string QuizResultId { get; set; } = Guid.NewGuid().ToString();
        public short QuizScore { get; set; }        
        public DateTime CreatedAt { get; set; }    
        public string Remark { get; set; }
        public ApplicationUser ApplicationUserId { get; set; }        
        public Quiz QuizId { get; set; }
    }
}
