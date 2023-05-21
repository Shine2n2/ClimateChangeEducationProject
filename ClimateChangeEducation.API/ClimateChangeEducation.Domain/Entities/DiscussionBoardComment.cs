using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class DiscussionBoardComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CommentedDate { get; set; }
        public ApplicationUser Author { get; set; }
        public DiscussionBoardPost PostId { get; set; }

    }
}
