﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Domain.Entities
{
    public class Student
    {
        public string StudentId { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Nickname { get; set; }
        public int Age { get; set; }
        public string StudentClass { get; set; }
        public string? AvatarUrl { get; set;}        
        public School School { get; set;}
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<DiscussionBoardComment>? DiscussionBoardComments { get; set; }
        public ICollection<Course>? Course { get; set; }
        public ICollection<CourseEnrollment>? CourseEnrollment { get; set; }
        public ICollection<QuizEnrollment>? QuizEnrollment { get; set; }
    } 
}
