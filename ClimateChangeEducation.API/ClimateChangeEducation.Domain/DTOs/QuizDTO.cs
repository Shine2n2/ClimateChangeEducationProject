using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class QuizDTO
    {        
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }       
        public string? CourseId { get; set; }      
    }
}
