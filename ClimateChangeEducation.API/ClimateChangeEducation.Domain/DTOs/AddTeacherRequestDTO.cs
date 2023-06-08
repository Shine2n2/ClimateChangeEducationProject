using ClimateChangeEducation.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class AddTeacherRequestDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string LastName { get; set; }
        public string? PhotoUrl { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Valid email is required")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string Email { get; set; }
        [Required]
        public string FieldOfStudy { get; set; }
        public School School { get; set; }                
    }
}
