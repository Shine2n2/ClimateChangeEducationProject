using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class DiscussionBoardComment
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 300 characters!")]
        public string? Content { get; set; }
        public DateTime CommentedDate { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<School> Schools { get; set; }       
        public DiscussionBoardPost DiscussionBoardPost { get; set; }

    }
}
