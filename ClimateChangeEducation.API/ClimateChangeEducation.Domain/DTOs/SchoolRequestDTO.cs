using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class SchoolRequestDTO
    {
        
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 60 characters!")]
        public string SchoolName { get; set; }
       
        [Required]
        [EmailAddress(ErrorMessage = "Valid Email is required!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 100 characters!")]
        public string SchoolEmail { get; set; }
        [Required]
        public string SupportingDocument { get; set; }
    }
}
