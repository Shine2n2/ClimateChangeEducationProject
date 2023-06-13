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
    public class EnrollmentRepository:IEnrollmentRepository
    {
        private readonly ClimateDataContext _dataContext;
        public EnrollmentRepository(ClimateDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CourseEnrollment> CreateCourseEnrollmentAsync(CourseEnrollment courseEnrollment)
        {
            var article = await _dataContext.CourseEnrollments.AddAsync(courseEnrollment);
            await _dataContext.SaveChangesAsync();
            return article.Entity;
        }

        public async Task<QuizEnrollment> CreateQuizEnrollmentAsync(QuizEnrollment quizEnrollment)
        {
            var article = await _dataContext.QuizEnrollments.AddAsync(quizEnrollment);
            await _dataContext.SaveChangesAsync();
            return article.Entity;
        }

        public async Task<bool> DeleteCourseEnrollment(string request)
        {
            var result = await GetCourseEnrollmentByIdAsync(request);
            if (result != null)
            {
                _dataContext.CourseEnrollments.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteQuizEnrollment(string request)
        {
            var result = await GetQuizEnrollmentByIdAsync(request);
            if (result != null)
            {
                _dataContext.QuizEnrollments.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ExistsCourseEnrollmentAsync(string id)
        {
            return await _dataContext.CourseEnrollments.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsQuizEnrollmentAsync(string id)
        {
            return await _dataContext.QuizEnrollments.AnyAsync(x => x.EnrollmentID == id);
        }

        public async Task<List<CourseEnrollment>> GetAllCourseEnrollmentAsync()
        {
            return await _dataContext.CourseEnrollments.Include(student => student.Student)
                .Include(course=>course.Course).ToListAsync();
        }

        public async Task<List<QuizEnrollment>> GetAllQuizEnrollmentAsync()
        {
            return await _dataContext.QuizEnrollments.Include(student => student.Student)
                .Include(course => course.Course).Include(quiz=>quiz.Quiz).ToListAsync();
        }

        public async Task<CourseEnrollment> GetCourseEnrollmentByIdAsync(string id)
        {
            return await _dataContext.CourseEnrollments
               .Include(course => course.Course).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CourseEnrollment> GetCourseEnrollmentByStudentIdAsync(string studentId)
        {
            return await _dataContext.CourseEnrollments
              .Include(student => student.Student).FirstOrDefaultAsync(x => x.Student.StudentId == studentId);
        }

        public async Task<QuizEnrollment> GetQuizEnrollmentByIdAsync(string id)
        {
            return await _dataContext.QuizEnrollments
              .Include(quiz => quiz.Quiz).FirstOrDefaultAsync(x => x.EnrollmentID == id);
        }

        public async Task<CourseEnrollment> GetQuizEnrollmentByStudentIdAsync(string studentId)
        {
            return await _dataContext.CourseEnrollments
              .Include(student => student.Student).Include(course=>course.Course)
              .FirstOrDefaultAsync(x => x.Student.StudentId == studentId);
        }

        public async Task<CourseEnrollment> UpdateCourseEnrollmentAsync(string Id, CourseEnrollment request)
        {
            var enrolledCourse = await GetCourseEnrollmentByIdAsync(Id);
            if (enrolledCourse != null)
            {                               
                enrolledCourse.IsCompleted = request.IsCompleted;
                await _dataContext.SaveChangesAsync();
                return enrolledCourse;
            }
            return null;
        }

        public async Task<QuizEnrollment> UpdateQuizEnrollmentAsync(string Id, QuizEnrollment request)
        {
            var enrolledQuiz = await GetQuizEnrollmentByIdAsync(Id);
            if (enrolledQuiz != null)
            {
                enrolledQuiz.QuizStartDate = request.QuizStartDate;
                enrolledQuiz.QuizScore = request.QuizScore;
                enrolledQuiz.Remark = request.Remark;
                enrolledQuiz.IsCompleted = request.IsCompleted;

                await _dataContext.SaveChangesAsync();
                return enrolledQuiz;
            }
            return null;
        }
    }
}
