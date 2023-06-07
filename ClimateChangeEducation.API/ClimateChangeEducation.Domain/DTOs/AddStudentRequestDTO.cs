using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClimateChangeEducation.Common.Helpers;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class AddStudentRequestDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = DataAnnotationHelper.FirstNameValidator)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = DataAnnotationHelper.LastNameValidator)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = DataAnnotationHelper.EmailValidator)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = DataAnnotationHelper.EmailLengthValidator)]
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
