using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class StudentRequestDTO
    {
        
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 60 characters!")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 60 characters!")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email is required")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string Email { get; set; }
        public string? Nickname { get; set; }
        [Required]
        public int Age { get; set; }
        public string? SchoolCode { get; set; }
        public string Password { get;}

    }
}
