using ClimateChangeEducation.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class ArticleDTO
    {
        
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string Title { get; set; }
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Max character is 250, min is 3")]
        public string? Description { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Max character is 1000, min is 3")]
        public string Content { get; set; }
        public string? MediaUrl { get; set; }        
        public ArticleCategory Category { get; set; }
    }
}
