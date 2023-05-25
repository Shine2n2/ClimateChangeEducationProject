﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class QuizEnrollment
    {
        [Key]
        public string EnrollmentID { get; set; } = Guid.NewGuid().ToString();
        public int StudentID { get; set; }                  
        public DateTime EnrollmentDate { get; set; }
        public int? SchoolId { get; set; }
        public int CourseId { get; set; }
        public int QuizScore { get; set; }
        public Quiz QuizId { get; set; }
    }
   
}
