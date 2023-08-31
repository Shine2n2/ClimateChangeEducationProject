using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class Teacher
    {
        public string TeacherId { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhotoUrl { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public string Email { get;set; }
        public string FieldOfStudy { get;set; }
        public bool IsAccountActive { get; set; }
        public string? UserAccountRole { get; set; }
        public string? SchoolCode { get; set; }
        public string? SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public virtual School? School { get; set; }
        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser? ApplicationUser { get; set; }
        [JsonIgnore]
        public ICollection<DiscussionBoardPost> DiscussionBoardPosts { get; set; }      
        public ICollection<DiscussionBoardComment> DiscussionBoardComments { get; set; }
        public ICollection<ReplyComment>? RepliedComments { get; set; }
    }
}
