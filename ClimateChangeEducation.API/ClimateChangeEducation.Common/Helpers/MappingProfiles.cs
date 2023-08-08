using AutoMapper;
using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Common.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {            
            CreateMap<Article, ArticleDTO>().ReverseMap();
            CreateMap<ArticleCategory, ArticleCategoryDTO>().ReverseMap();
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<CourseEnrollment, CourseEnrollmentDTO>().ReverseMap();
            CreateMap<CourseLesson, CourseLessonDTO>().ReverseMap();
            CreateMap<CourseModule, CourseModuleDTO>().ReverseMap();
            CreateMap<DiscussionBoard, DiscussionBoardDTO>().ReverseMap();
            CreateMap<DiscussionBoardComment, DiscussionBoardCommentDTO>().ReverseMap();
            CreateMap<DiscussionBoardPost, DiscussionBoardPostDTO>().ReverseMap();
            CreateMap<QuestionAnswer, QuestionAnswerDTO>().ReverseMap();
            CreateMap<Quiz, QuizDTO>().ReverseMap();
            CreateMap<QuizEnrollment, QuizEnrollmentDTO>().ReverseMap();
            CreateMap<QuizQuestion, QuizQuestionDTO>().ReverseMap();           
            CreateMap<Student, StudentRequestDTO>().ReverseMap();           
            CreateMap<Teacher, TeacherRequestDTO>().ReverseMap();          
            CreateMap<School, SchoolRequestDTO>().ReverseMap();
            CreateMap<ContactUs, ContactUsDTO>().ReverseMap();
            CreateMap<NoticeBoard, NoticeBoardDTO>().ReverseMap();
        }
    }
}
