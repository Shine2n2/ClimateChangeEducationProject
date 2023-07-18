using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class DiscussionBoardPostDTO
    {
        public string? PostId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 1000 characters!")]
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsPublished { get; set; }
        public string? TeacherId { get; set; }
        public string? SchoolId { get; set; }    
    }
}
