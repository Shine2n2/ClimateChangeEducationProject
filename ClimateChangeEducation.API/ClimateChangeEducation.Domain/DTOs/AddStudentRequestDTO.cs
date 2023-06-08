using ClimateChangeEducation.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class AddStudentRequestDTO
    {        

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email is required")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string Email { get; set; }
        public string? Nickname { get; set; }
        [Required]
        [StringLength(22, MinimumLength = 10, ErrorMessage = "minimun entry 8, maximum entry 22")]
        public int Age { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Min length is 3 and max length is 25")]
        public string StudentClass { get; set; }
        public string? AvatarUrl { get; set; }
        public School? School { get; set; }        
    }
}
