using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClimateChangeEducation.Domain.Entities
{
    public class DiscussionBoardPost
    {
        [Key]
        public string PostId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Title { get; set; }
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 300 characters!")]
        public string Content { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool IsPublished { get; set; } = true;
        public string? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher? Teacher { get; set; }
        public string? SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public virtual School? School { get; set; }
        public string? DiscussionBoardId { get; set; }
        [ForeignKey("DiscussionBoardId")]
        public virtual DiscussionBoard? DiscussionBoard { get; set; }
        public ICollection<DiscussionBoardComment>? Comments { get; set; }

    }
}
