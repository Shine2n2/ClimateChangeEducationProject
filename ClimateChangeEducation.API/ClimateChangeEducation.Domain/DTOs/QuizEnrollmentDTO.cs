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
        public string? Id { get; set; }
        public DateTime QuizStartDate { get; set; }
        public short QuizScore { get; set; }
        public string Remark { get; set; }
        public bool IsCompleted { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public Quiz Quiz { get; set; }
    }
}
