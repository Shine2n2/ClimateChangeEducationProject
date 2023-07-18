using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class DiscussionBoard
    {
        [Key]
        public string DiscussionBoardId { get; set; } = Guid.NewGuid().ToString();       
        public string Title { get; set; }       
        public ICollection<DiscussionBoardPost> Posts { get; set; }        
    }
}
