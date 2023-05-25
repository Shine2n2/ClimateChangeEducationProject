using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public Task<List<Course>> CreateCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseLesson>> CreateCourseAsync(CourseLesson courseLlesson)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseModule>> CreateCourseModuleAsync(CourseModule courseModule)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourse(Course request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourseLesson(CourseLesson request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourseModule(CourseModule request)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseLesson>> GetAllCourseLessonsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseModule>> GetAllCourseModulesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetAllCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetCourseByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CourseLesson> GetCourseLessonByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CourseModule> GetCourseModuleByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCourseAsync(Course request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCourseLessonAsync(CourseLesson request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCourseModuleAsync(CourseModule request)
        {
            throw new NotImplementedException();
        }
    }
}
