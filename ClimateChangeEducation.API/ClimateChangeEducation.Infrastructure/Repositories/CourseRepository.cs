using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Data;
using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ClimateDataContext _dataContext;
        public CourseRepository(ClimateDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Course> CreateCourseAsync(Course course)
        {
            var result =  await _dataContext.Courses.AddAsync(course);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<CourseLesson> CreateCourseLessonAsync(CourseLesson courseLlesson)
        {
            var result = await _dataContext.CourseLessons.AddAsync(courseLlesson);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<CourseModule> CreateCourseModuleAsync(CourseModule courseModule)
        {
            var result = await _dataContext.CourseModules.AddAsync(courseModule);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteCourse(string requestId)
        {
            var result = await GetCourseByIdAsync(requestId);
            if (result != null)
            {
                _dataContext.Courses.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCourseLesson(string requestId)
        {
            var result = await GetCourseLessonByIdAsync(requestId);
            if (result != null)
            {
                _dataContext.CourseLessons.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCourseModule(string requestId)
        {
            var result = await GetCourseModuleByIdAsync(requestId);
            if (result != null)
            {
                _dataContext.CourseModules.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ExistsCourseAsync(string id)
        {
            return await _dataContext.Courses.AnyAsync(x => x.CourseId == id);
        }

        public async Task<bool> ExistsCourseLessonAsync(string id)
        {
            return await _dataContext.CourseLessons.AnyAsync(x => x.LessonId == id);
        }

        public async Task<bool> ExistsCourseModuleAsync(string id)
        {
            return await _dataContext.CourseModules.AnyAsync(x => x.ModuleId == id);
        }

        public async Task<List<CourseLesson>> GetAllCourseLessonsAsync()
        {
            return await _dataContext.CourseLessons.Include(courseLesson => courseLesson.CourseModule).ToListAsync();            
        }

        public async Task<List<CourseModule>> GetAllCourseModulesAsync()
        {
            return await _dataContext.CourseModules.Include(x=> x.Lessons).Include(x=>x.Course).ToListAsync();              
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _dataContext.Courses
                .Include(x=>x.Quiz)
                .Include(y=>y.CourseModules)
                .Include(z=>z.CourseEnrollments).ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(string id)
        {
            return await _dataContext.Courses
                .Include(x => x.Quiz).Include(y => y.CourseModules)
                .Include(z=>z.CourseEnrollments).FirstOrDefaultAsync(x => x.CourseId == id);
            //return await _dataContext.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
        }

        public async Task<CourseLesson> GetCourseLessonByIdAsync(string id)
        {
            return await _dataContext.CourseLessons.Include(x => x.CourseModule).FirstOrDefaultAsync(x => x.LessonId == id);
            //return await _dataContext.CourseLessons.FirstOrDefaultAsync(x => x.LessonId == id);
        }

        public async Task<CourseModule> GetCourseModuleByIdAsync(string id)
        {
            return await _dataContext.CourseModules.Include(x=>x.Course).FirstOrDefaultAsync(x => x.ModuleId == id);
        }

        public async Task<Course> UpdateCourseAsync(string id, Course course)
        {
            var existingCourse = await GetCourseByIdAsync(id);
            if (existingCourse != null)
            {
                existingCourse.CourseTitle = course.CourseTitle;
                existingCourse.CourseDescription = course.CourseDescription;
                existingCourse.CourseEndDateTime = course.CourseEndDateTime;
                existingCourse.CourseEndDateTime = course.CourseEndDateTime;                           

                await _dataContext.SaveChangesAsync();
                return existingCourse;
            }
            return null;
        }

        public async Task<CourseLesson> UpdateCourseLessonAsync(string id, CourseLesson request)
        {
            var existingCourseLesson = await GetCourseLessonByIdAsync(id);
            if (existingCourseLesson != null)
            {   
                existingCourseLesson.LessonName = request.LessonName;
                existingCourseLesson.LessonDuration = request.LessonDuration;
                existingCourseLesson.LessonDescription = request.LessonDescription;
                existingCourseLesson.LessonVideoUrl = request.LessonVideoUrl;
                existingCourseLesson.LessonPhotoUrl = request.LessonPhotoUrl;
                existingCourseLesson.LessonArticle = request.LessonArticle;

                await _dataContext.SaveChangesAsync();
                return existingCourseLesson;
            }
            return null;
        }

        public async Task<CourseModule> UpdateCourseModuleAsync(string id, CourseModule request)
        {
            var existingCourseModule = await GetCourseModuleByIdAsync(id);
            if (existingCourseModule != null)
            {
                existingCourseModule.ModuleName = request.ModuleName;
                existingCourseModule.ModuleDescription = request.ModuleDescription;
                existingCourseModule.MediaUrl = request.MediaUrl;
                await _dataContext.SaveChangesAsync();
                return existingCourseModule;
            }
            return null;
        }

        public async Task<bool> UpdateLessonImage(string studentId, string ImageUrl)
        {
            var lesson = await GetCourseLessonByIdAsync(studentId);
            if (lesson != null)
            {
                lesson.LessonPhotoUrl = ImageUrl;
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateLessonVideo(string studentId, string VideoUrl)
        {
            var lesson = await GetCourseLessonByIdAsync(studentId);
            if (lesson != null)
            {
                lesson.LessonVideoUrl = VideoUrl;
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
