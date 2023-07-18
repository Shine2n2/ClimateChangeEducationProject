using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class QuizQuestionDTO
    {
        public string? QuizQuestionId { get; set; }
        [Required]
        public string Text { get; set; }
        public string? MediaUrl { get; set; }
        public string? QuizId { get; set; }
    }
}
