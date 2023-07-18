using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class DiscussionBoardComment
    {
        [Key]
        public string CommentId { get; set; } = Guid.NewGuid().ToString();
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 300 characters!")]
        public string Content { get; set; }
        public DateTime CommentedDate { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<School> Schools { get; set; }   
        public string? PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual DiscussionBoardPost DiscussionBoardPost { get; set; }

    }
}
