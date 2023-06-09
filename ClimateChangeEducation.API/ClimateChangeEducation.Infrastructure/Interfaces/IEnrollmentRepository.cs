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
        Task<List<QuizEnrollment>> GetAllArticleAsync();
        Task<QuizEnrollment> GetArticleByIdAsync(string id);
        Task<QuizEnrollment> CreateArticleAsync(QuizEnrollment quizEnrollment);
        Task<QuizEnrollment> UpdateArticleAsync(string Id, QuizEnrollment request);
        Task<bool> DeleteArticle(string request);

        //course enrollment repo
        Task<List<QuizEnrollment>> GetAllArticleCategoryAsync();
        Task<QuizEnrollment> GetArticleCategoryByIdAsync(string id);
        Task<QuizEnrollment> CreateArticleCategoryAsync(QuizEnrollment quizEnrollment);
        Task<QuizEnrollment> UpdateArticleCategoryAsync(string Id, QuizEnrollment request);
        Task<bool> DeleteArticleCategory(string request);
        Task<bool> ExistsArticleCategoryAsync(string id);
        Task<bool> ExistsArticleAsync(string id);
    }
}
