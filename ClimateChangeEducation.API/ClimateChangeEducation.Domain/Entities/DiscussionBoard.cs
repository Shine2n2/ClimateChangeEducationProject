using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class DiscussionBoard
    {
        public int Id { get; set; }
        public string Title { get; set; }       
        public ICollection<DiscussionBoardPost> Posts { get; set; }
        //public ICollection<ApplicationUser> Members { get; set; }
    }
}
