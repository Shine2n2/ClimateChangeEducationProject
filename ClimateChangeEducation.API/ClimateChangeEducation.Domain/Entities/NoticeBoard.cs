﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class NoticeBoard
    {
        [Key]
        public string NoticeId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string NoticeTitle { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Character must be between 3 and 150 characters!")]
        public string? NoticeDescription { get; set; }
        public string NoticeContent { get; set; }
        public string? DisplayPhoto { get; set; }
        public DateTime PublishStartDateTime { get; set; }
        public DateTime PublishEndDateTime { get; set; }
        public bool IsPublished { get; set; }
        public School? School { get; set; }
       
    }
}
