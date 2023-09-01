using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class QuestionAnswerDTO
    {
        public string? Id { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string Text { get; set; }
        [Required]
        public int? AllocatedScore { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
        public string QuizQuestionId { get; set; }        
    }
}
