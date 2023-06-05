using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Interfaces
{
    public interface IQuizRepository
    {
        //---------quiz interfaces
        

        //------quiz question

        Task<List<QuizQuestion>> GetAllQuizQuestionsAsync();
        Task<QuizQuestion> GetQuizQuestionByIdAsync(string id);
        Task<QuizQuestion> CreateQuizQuestionAsync(QuizQuestion quizQuestion);
        Task<QuizQuestion> UpdateQuizQuestionAsync(string id, QuizQuestion request);
        Task<bool> DeleteQuizQuestion(string id);

        // -------------Question answer option interfaces

        Task<List<QuestionAnswer>> GetAllQuestionAnswersAsync();
        Task<QuestionAnswer> GetQuizQuestionAnswerByIdAsync(string id);
        Task<QuestionAnswer> CreateQuestionAnswerAsync(QuestionAnswer quizQuestion);
        Task<QuestionAnswer> UpdateQuestionAnswerAsync(string id, QuestionAnswer request);
        Task<bool> DeleteQuestionAnswer(string id);

    }
}
