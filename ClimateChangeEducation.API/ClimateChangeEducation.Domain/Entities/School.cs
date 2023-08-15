using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimateChangeEducation.Domain.Entities
{
    public class School
    {
        public string SchoolId { get; set; } = Guid.NewGuid().ToString();
        public string SchoolCode { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 150 characters!")]
        public string SchoolName { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Valid Email is required")]
        public string SchoolEmail { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public string? SupportingDocument { get; set; }
        public bool IsAccountActive { get; set; }
        public string? UserAccountRole { get; set; }
        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]    
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Teacher>? Teachers { get; set; }
        public ICollection<DiscussionBoardPost>? DiscussionBoardPosts { get; set; }
        public ICollection<DiscussionBoardComment>? DiscussionBoardComments { get; set; }
    }
}
