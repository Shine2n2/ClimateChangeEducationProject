using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Interfaces
{
    public interface ICourseRepository
    {
        //-------Course
        Task<List<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(string id);
        Task<Course> CreateCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(string id, Course request);
        Task<bool> DeleteCourse(string requestId);

        //----------CourseLesson

        Task<List<CourseLesson>> GetAllCourseLessonsAsync();
        Task<CourseLesson> GetCourseLessonByIdAsync(string id);
        Task<CourseLesson> CreateCourseLessonAsync(CourseLesson courseLlesson);
        Task<CourseLesson> UpdateCourseLessonAsync(string id, CourseLesson request);
        Task<bool> DeleteCourseLesson(string requestId);

        // ------------ CourseModule

        Task<List<CourseModule>> GetAllCourseModulesAsync();
        Task<CourseModule> GetCourseModuleByIdAsync(string id);
        Task<CourseModule> CreateCourseModuleAsync(CourseModule courseModule);
        Task<CourseModule> UpdateCourseModuleAsync(string id, CourseModule request);
        Task<bool> DeleteCourseModule(string requestId);
    }
}
