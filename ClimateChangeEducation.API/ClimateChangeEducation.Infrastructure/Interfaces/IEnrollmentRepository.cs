using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Interfaces
{
    public interface IEnrollmentRepository
    {
        //Quiz enrollment repo interface
        Task<List<QuizEnrollment>> GetAllQuizEnrollmentAsync();
        Task<CourseEnrollment> GetQuizEnrollmentByStudentIdAsync(string id);
        Task<QuizEnrollment> GetQuizEnrollmentByIdAsync(string id);
        Task<QuizEnrollment> CreateQuizEnrollmentAsync(QuizEnrollment quizEnrollment);
        Task<QuizEnrollment> UpdateQuizEnrollmentAsync(string Id, QuizEnrollment request);
        Task<bool> DeleteQuizEnrollment(string request);

        //course enrollment repo
        Task<List<CourseEnrollment>> GetAllCourseEnrollmentAsync();
        Task<CourseEnrollment> GetCourseEnrollmentByStudentIdAsync(string id);
        Task<CourseEnrollment> GetCourseEnrollmentByIdAsync(string id);
        Task<CourseEnrollment> CreateCourseEnrollmentAsync(CourseEnrollment courseEnrollment);
        Task<CourseEnrollment> UpdateCourseEnrollmentAsync(string Id, CourseEnrollment request);
        Task<bool> DeleteCourseEnrollment(string request);
        Task<bool> ExistsCourseEnrollmentAsync(string id);
        Task<bool> ExistsQuizEnrollmentAsync(string id);
    }
}
