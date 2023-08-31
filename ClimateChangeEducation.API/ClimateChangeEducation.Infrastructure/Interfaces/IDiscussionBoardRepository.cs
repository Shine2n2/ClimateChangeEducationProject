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
        Task<List<DiscussionBoardPost>> GetDiscussionBoardByIdAsync(string id);
        Task<DiscussionBoard> CreateDiscussionBoardAsync(DiscussionBoard request);
        Task<DiscussionBoardPost> UpdateDiscussionBoardAsync(string id, DiscussionBoard request);
        Task<bool> DeleteDiscussionBoard(string request);
        Task<bool> ExistsDiscussionBoardAsync(string id);

        //-----------Discussion board post

        Task<List<DiscussionBoardPost>> GetAllDiscussionBoardPostAsync();
        Task<DiscussionBoardPost> GetDiscussionBoardPostByIdAsync(string id);
        Task<DiscussionBoardPost> CreateDiscussionBoardPostAsync(DiscussionBoardPost request);
        Task<DiscussionBoardPost> UpdateDiscussionBoardPostAsync(string id, DiscussionBoardPost request);
        Task<bool> DeleteDiscussionBoardPost(string request);
        Task<bool> ExistsDiscussionBoardPostAsync(string id);

        //------------------DiscussionBoardComment

        Task<List<DiscussionBoardComment>> GetAllDiscussionBoardCommentAsync();
        Task<DiscussionBoardComment> GetDiscussionBoardCommentByIdAsync(string id);
        Task<DiscussionBoardComment> CreateDiscussionBoardCommentAsync(DiscussionBoardComment request);
        Task<DiscussionBoardComment> UpdateDiscussionBoardCommentAsync(string id, DiscussionBoardComment request);
        Task<bool> DeleteDiscussionBoardComment(string request);
        Task<bool> ExistsDiscussionBoardCommentAsync(string id);
        Task<DiscussionBoardComment> GetCommentByPostIdAsync(string postId);
    }
}
