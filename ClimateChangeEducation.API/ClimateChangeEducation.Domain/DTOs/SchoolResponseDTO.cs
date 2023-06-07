using ClimateChangeEducation.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class SchoolResponseDTO
    {
        public string SchoolCode { get; set; }           
        public string SchoolName { get; set; }
        public string SchoolEmail { get; set; }
    }
}
