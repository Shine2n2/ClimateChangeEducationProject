using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class ApplicationUser:IdentityUser
    {
        [Key]
        public string ApplicationUserId { get; set; } = Guid.NewGuid().ToString();
        //[Required]
        //[EmailAddress]
        //[MaxLength(50)]
        //public string UserEmail { get; set; }
        //[Required]
        //[MaxLength(20)]
        //public string UserName { get; set; }  
                 
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;

        // navigation props        
        public School School { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public ICollection<DiscussionBoard> DiscussionBoards { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
        public ICollection<Article> Articles { get; set; }
        
        public ApplicationUser()
        {
            //Articles = new List<Article>();
            //Photos = new List<Photo>();
            //UserStacks = new List<UserStack>();
            //UserSquads = new List<UserSquad>();
            //UserComment = new List<UserComment>();
        }
    }
}
