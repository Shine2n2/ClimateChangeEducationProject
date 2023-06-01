using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class Teacher
    {
        public string TeacherId { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string Email { get;set; }
        public string FieldOfStudy { get;set; }
        public School SchoolId { get; set; }      
        public ICollection<DiscussionBoardPost> DiscussionBoardPosts { get; set; }      
        public ICollection<DiscussionBoardComment> DiscussionBoardComments { get; set; }      
    }
}
