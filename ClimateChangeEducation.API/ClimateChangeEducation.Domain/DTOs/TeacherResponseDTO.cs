﻿using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class TeacherResponseDTO
    {
        public string TeacherId { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }        
        public string Email { get; set; }        
        public string FieldOfStudy { get; set; }
        public string SchoolCode { get; set; }
        public string SchoolId { get; set; }

    }
}
