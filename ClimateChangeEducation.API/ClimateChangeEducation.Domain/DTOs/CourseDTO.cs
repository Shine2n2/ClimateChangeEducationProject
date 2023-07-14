﻿using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class CourseDTO
    {
        public string? Id { get; set; }
        [Required]
        public string CourseTitle { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 150 characters!")]
        public string? CourseDescription { get; set; }
        public DateTime CourseStartDateTime { get; set; }
        public DateTime CourseEndDateTime { get; set; }
        public bool IsEnrolled { get; set; }        
    }
}
