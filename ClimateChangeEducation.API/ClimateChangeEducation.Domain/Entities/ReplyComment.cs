using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class ReplyComment
    {
        public string ReplyCommentId { get; set; }
        public string Comment { get; set; }
        public string? CommentId { get; set; }    
        [ForeignKey("CommentId")]
        public virtual DiscussionBoardComment? DiscussionBoardComment { get; set; }
        public string? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student? Student { get; set; }
        public string? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher? Teacher { get; set; }
    }
}
