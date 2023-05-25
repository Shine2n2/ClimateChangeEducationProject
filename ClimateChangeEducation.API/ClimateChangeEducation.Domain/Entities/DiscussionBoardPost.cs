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
