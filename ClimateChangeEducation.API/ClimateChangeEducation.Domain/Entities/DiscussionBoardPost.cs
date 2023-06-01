using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClimateChangeEducation.Domain.Entities
{
    public class DiscussionBoardPost
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Title { get; set; }
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 300 characters!")]
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsPublished { get; set; }
        public Teacher Teacher { get; set; }
        public School School { get; set; }
        public DiscussionBoard DiscussionBoard { get; set; }
        public ICollection<DiscussionBoardComment>? Comments { get; set; }

    }
}
