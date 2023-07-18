using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class CourseModuleDTO
    {
        public string? Id { get; set; }

        [Required]
        public string ModuleName { get; set; }
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 150 characters!")]
        public string? ModuleDescription { get; set; }
        public string? MediaUrl { get; set; }     
        public string CourseId { get; set; }     
    }
}
