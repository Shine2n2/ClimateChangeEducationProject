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
    public class QuizRepository : IQuizRepository
    {
        private readonly ClimateDataContext _dataContext;
        public QuizRepository(ClimateDataContext dataContext)
        {
            _dataContext = dataContext;
        }
      
        public async Task<QuestionAnswer> CreateQuestionAnswerAsync(QuestionAnswer quizQuestion)
        {
            var result = await _dataContext.QuestionAnswers.AddAsync(quizQuestion);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Quiz> CreateQuizAsync(Quiz quiz)
        {
            var result = await _dataContext.Quizzes.AddAsync(quiz);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<QuizQuestion> CreateQuizQuestionAsync(QuizQuestion quizQuestion)
        {
            var result = await _dataContext.QuizQuestions.AddAsync(quizQuestion);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }       

        public async Task<bool> DeleteQuestionAnswerAsync(string id)
        {
            var result = await GetQuizQuestionAnswerByIdAsync(id);
            if (result != null)
            {
                _dataContext.QuestionAnswers.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteQuizAsync(string id)
        {
            var result = await GetQuizByIdAsync(id);
            if (result != null)
            {
                _dataContext.Quizzes.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteQuizQuestionAsync(string id)
        {
            var result = await GetQuizQuestionByIdAsync(id);
            if (result != null)
            {
                _dataContext.QuizQuestions.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ExistsQuestionAnswerAsync(string id)
        {
            return await _dataContext.QuestionAnswers.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsQuizAsync(string id)
        {
            return await _dataContext.Quizzes.AnyAsync(x => x.QuizId == id);
        }

        public async Task<bool> ExistsQuizQuestionAsync(string id)
        {            
            return await _dataContext.QuizQuestions.AnyAsync(x => x.QuizQuestionId == id);
        }

        public async Task<List<QuestionAnswer>> GetAllQuestionAnswersAsync()
        {
            return await _dataContext.QuestionAnswers.ToListAsync();
        }

        public async Task<List<QuizQuestion>> GetAllQuizQuestionsAsync()
        {
            return await _dataContext.QuizQuestions.ToListAsync();
        }

        public async Task<List<Quiz>> GetAllQuizzesAsync()
        {
            return await _dataContext.Quizzes.ToListAsync();
        }

        public async Task<Quiz> GetQuizByIdAsync(string id)
        {
            return await _dataContext.Quizzes.FirstOrDefaultAsync(x => x.QuizId == id);
        }

        public async Task<QuestionAnswer> GetQuizQuestionAnswerByIdAsync(string id)
        {
            return await _dataContext.QuestionAnswers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<QuizQuestion> GetQuizQuestionByIdAsync(string id)
        {
            return await _dataContext.QuizQuestions.FirstOrDefaultAsync(x => x.QuizQuestionId == id);
        }

        public async Task<Quiz> GetQuizByCourseIdAsync(string id)
        {
            return await _dataContext.Quizzes
                .Include(x => x.Course).Include(y => y.QuizQuestions)
                .FirstOrDefaultAsync(x => x.CourseId == id);
            //return await _dataContext.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
        }

        public async Task<QuestionAnswer> UpdateQuestionAnswerAsync(string id, QuestionAnswer request)
        {
            var result = await GetQuizQuestionAnswerByIdAsync(id);
            if (result != null)
            {
                result.Text = request.Text;
                result.IsCorrect = result.IsCorrect;
                result.AllocatedScore = result.AllocatedScore;                
                return result;
            }
            return null;
        }

        public async Task<Quiz> UpdateQuizAsync(string id, Quiz request)
        {
            var result = await GetQuizByIdAsync(id);
            if (result != null)
            {
                result.Title = request.Title;
                result.Description = request.Description;
                result.UpdatedAt= request.UpdatedAt;               
            }
            return null;
        }

        public async Task<QuizQuestion> UpdateQuizQuestionAsync(string id, QuizQuestion request)
        {
            var result = await GetQuizQuestionByIdAsync(id);
            if (result != null)
            {
                result.Text = request.Text;
                result.MediaUrl = request.MediaUrl;                                              
                return result;
            }
            return null;
        }
    }
}
