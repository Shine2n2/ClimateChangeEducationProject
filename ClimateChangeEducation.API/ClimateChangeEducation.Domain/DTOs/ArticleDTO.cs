using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClimateChangeEducation.Common.Helpers;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class ArticleDTO
    {
        
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = DataAnnotationHelper.TitleChar)]
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
