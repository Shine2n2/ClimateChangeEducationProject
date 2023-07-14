using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.DTOs
{
    public class CourseEnrollmentDTO
    {
        public string? Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsCompleted { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
