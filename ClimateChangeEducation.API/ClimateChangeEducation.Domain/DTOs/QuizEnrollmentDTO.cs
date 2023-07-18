using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class QuizEnrollmentDTO
    {
        public string? EnrollmentID { get; set; }
        public DateTime QuizStartDate { get; set; }
        public short QuizScore { get; set; }
        public string Remark { get; set; }
        public bool IsCompleted { get; set; }
        public string? StudentId { get; set; }
        public string? CourseId { get; set; }
        public string? QuizId { get; set; }
    }
}
