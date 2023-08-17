using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class SchoolSingleRequestDTO
    {
               
        public string SchoolName { get; set; }            
        public string SchoolEmail { get; set; }
        public string? SupportingDocument { get; set; }
        public IFormFile? File { get; set; }       
        public string Password { get; set; }
    }
}
