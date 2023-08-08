using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class TeacherRequestDTO
    {
        public string? Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string LastName { get; set; }
        public string? PhotoUrl { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Valid Email is required!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string FieldOfStudy { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string SchoolCode { get; set; }
        public string SchoolId { get; set; }
        public string Password { get; set; }
    }
}
