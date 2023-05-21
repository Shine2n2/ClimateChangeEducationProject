using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClimateChangeEducation.Domain.Entities
{
    public class DiscussionBoardPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsPublished { get; set; }
        public ApplicationUser Author { get; set; }
        public DiscussionBoard DiscussionBoard { get; set; }
        public ICollection<DiscussionBoardComment>? Comments { get; set; }

    }
}
