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
        Task<List<Quiz>> GetAllDiscussionBoardAsync();
        Task<Quiz> GetDiscussionBoardByIdAsync(string id);
        Task<List<Quiz>> CreateDiscussionBoardAsync(Quiz course);
        Task<bool> UpdateDiscussionBoardAsync(Quiz request);
        Task<bool> DeleteDiscussionBoard(Quiz request);

        //------quiz question

        Task<List<QuizQuestion>> GetAllQuizQuestionsAsync();
        Task<QuizQuestion> GetQuizQuestionByIdAsync(string id);
        Task<List<QuizQuestion>> CreateQuizQuestionAsync(QuizQuestion quizQuestion);
        Task<bool> UpdateQuizQuestionAsync(QuizQuestion request);
        Task<bool> DeleteQuizQuestion(QuizQuestion request);

        // -------------Question answer option interfaces

        Task<List<QuestionAnswer>> GetAllQuestionAnswersAsync();
        Task<QuestionAnswer> GetQuizQuestionAnswerByIdAsync(string id);
        Task<List<QuestionAnswer>> CreateQuestionAnswerAsync(QuestionAnswer quizQuestion);
        Task<bool> UpdateQuestionAnswerAsync(QuestionAnswer request);
        Task<bool> DeleteQuestionAnswer(QuestionAnswer request);

    }
}
