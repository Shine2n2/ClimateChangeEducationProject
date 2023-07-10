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
        public string SchoolName { get; set; }
        [Required]
        public string SchoolEmail { get; set; }
        [Required]
        public string SupportingDocument { get; set; }
    }
}
