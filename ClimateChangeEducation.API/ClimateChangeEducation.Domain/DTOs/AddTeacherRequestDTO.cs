using ClimateChangeEducation.Common.Helpers;
using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class AddTeacherRequestDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = DataAnnotationHelper.FirstNameValidator)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = DataAnnotationHelper.LastNameValidator)]
        public string LastName { get; set; }
        public string? PhotoUrl { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = DataAnnotationHelper.EmailValidator)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = DataAnnotationHelper.EmailLengthValidator)]
        public string Email { get; set; }
        [Required]
        public string FieldOfStudy { get; set; }
        public School School { get; set; }                
    }
}
