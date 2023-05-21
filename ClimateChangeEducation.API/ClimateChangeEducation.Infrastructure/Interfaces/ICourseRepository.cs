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
        Task<List<Course>> CreateCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(Course request);
        Task<bool> DeleteCourse(Course request);

        //----------CourseLesson

        Task<List<CourseLesson>> GetAllCourseLessonsAsync();
        Task<CourseLesson> GetCourseLessonByIdAsync(string id);
        Task<List<CourseLesson>> CreateCourseAsync(CourseLesson courseLlesson);
        Task<bool> UpdateCourseLessonAsync(CourseLesson request);
        Task<bool> DeleteCourseLesson(CourseLesson request);

        // ------------ CourseModule

        Task<List<CourseModule>> GetAllCourseModulesAsync();
        Task<CourseModule> GetCourseModuleByIdAsync(string id);
        Task<List<CourseModule>> CreateCourseModuleAsync(CourseModule courseModule);
        Task<bool> UpdateCourseModuleAsync(CourseModule request);
        Task<bool> DeleteCourseModule(CourseModule request);
    }
}
