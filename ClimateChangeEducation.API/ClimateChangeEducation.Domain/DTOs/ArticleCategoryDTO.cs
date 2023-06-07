﻿using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class ArticleCategoryDTO
    {        
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }        
    }
}
