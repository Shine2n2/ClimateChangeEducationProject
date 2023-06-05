using ClimateChangeEducation.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class School
    {
        public string SchoolId { get; set; } = Guid.NewGuid().ToString();
        public string SchoolCode { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = DataAnnotationHelper.SchoolName)]
        public string SchoolName { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = DataAnnotationHelper.EmailValidator)]
        public string SchoolEmail { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Teacher>? Teachers { get; set; }
        public ICollection<DiscussionBoardPost>? DiscussionBoardPosts { get; set; }
        public ICollection<DiscussionBoardComment>? DiscussionBoardComments { get; set; }
    }
}
