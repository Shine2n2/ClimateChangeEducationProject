using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class Article
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        [Required]
        public ArticleCategory Category { get; set; }
    }
}
