using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Interfaces
{
    public interface IDiscussionBoardRepository
    {
        //-----DiscussionBoard
        Task<List<DiscussionBoard>> GetAllDiscussionBoardAsync();
        Task<DiscussionBoard> GetDiscussionBoardByIdAsync(string id);
        Task<List<DiscussionBoard>> CreateDiscussionBoardAsync(Course course);
        Task<bool> UpdateDiscussionBoardAsync(DiscussionBoard request);
        Task<bool> DeleteDiscussionBoard(DiscussionBoard request);

        //-----------Discussion board post

        Task<List<DiscussionBoardPost>> GetAllDiscussionBoardPostAsync();
        Task<DiscussionBoardPost> GetDiscussionBoardPostByIdAsync(string id);
        Task<List<DiscussionBoardPost>> CreateDiscussionBoardPostAsync(DiscussionBoardPost course);
        Task<bool> UpdateDiscussionBoardPostAsync(DiscussionBoardPost request);
        Task<bool> DeleteDiscussionBoardPost(DiscussionBoardPost request);

        //------------------DiscussionBoardComment

        Task<List<DiscussionBoardComment>> GetAllDiscussionBoardCommentAsync();
        Task<DiscussionBoardComment> GetDiscussionBoardCommentByIdAsync(string id);
        Task<List<DiscussionBoardComment>> CreateDiscussionBoardCommentAsync(DiscussionBoardComment course);
        Task<bool> UpdateDiscussionBoardCommentAsync(DiscussionBoardComment request);
        Task<bool> DeleteDiscussionBoardComment(DiscussionBoardComment request);
    }
}
