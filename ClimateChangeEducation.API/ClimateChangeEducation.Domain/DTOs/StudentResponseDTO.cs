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
    public class StudentResponseDTO
    {        
        public string FirstName { get; set; }        
        public string LastName { get; set; }      
        public string Email { get; set; }
        public string? Nickname { get; set; }        
        public int Age { get; set; }
        public string StudentClass { get; set; }
        public string AvatarUrl { get; set; }
        public School School { get; set; } 
    }
}
