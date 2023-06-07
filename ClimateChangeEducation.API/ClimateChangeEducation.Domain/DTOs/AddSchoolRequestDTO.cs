using ClimateChangeEducation.Common.Helpers;
using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class AddSchoolRequestDTO
    {        
        public string SchoolCode { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = DataAnnotationHelper.SchoolName)]
        public string SchoolName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = DataAnnotationHelper.EmailValidator)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = DataAnnotationHelper.EmailValidator)]
        public string SchoolEmail { get; set; }       
    }
}
