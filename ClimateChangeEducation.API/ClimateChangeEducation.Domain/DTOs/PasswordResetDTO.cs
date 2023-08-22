using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class PasswordResetDTO
    {        
        public string Token { get; set; }
        public string NewPassword { get; set; }
        public string ToEmail { get; set; }

    }
}
