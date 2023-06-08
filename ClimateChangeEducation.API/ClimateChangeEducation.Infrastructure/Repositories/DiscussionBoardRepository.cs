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
    public class DiscussionBoardRepository : IDiscussionBoardRepository
    {
        private readonly ClimateDataContext _dataContext;
        public DiscussionBoardRepository(ClimateDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<DiscussionBoard> CreateDiscussionBoardAsync(DiscussionBoard request)
        {
            var result = await _dataContext.DiscussionBoards.AddAsync(request);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<DiscussionBoardComment> CreateDiscussionBoardCommentAsync(DiscussionBoardComment request)
        {
            var result = await _dataContext.DiscussionBoardComments.AddAsync(request);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<DiscussionBoardPost> CreateDiscussionBoardPostAsync(DiscussionBoardPost request)
        {
            var result = await _dataContext.DiscussionBoardPost.AddAsync(request);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteDiscussionBoard(string request)
        {
            var result = await GetDiscussionBoardByIdAsync(request);
            if (result != null)
            {
                _dataContext.DiscussionBoards.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteDiscussionBoardComment(string request)
        {
            var result = await GetDiscussionBoardCommentByIdAsync(request);
            if (result != null)
            {
                _dataContext.DiscussionBoardComments.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteDiscussionBoardPost(string request)
        {
            var result = await GetDiscussionBoardPostByIdAsync(request);
            if (result != null)
            {
                _dataContext.DiscussionBoardPost.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ExistsDiscussionBoardAsync(string id)
        {
            return await _dataContext.DiscussionBoards.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsDiscussionBoardCommentAsync(string id)
        {
            return await _dataContext.DiscussionBoardComments.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsDiscussionBoardPostAsync(string id)
        {
            return await _dataContext.DiscussionBoardPost.AnyAsync(x => x.Id == id);
        }

        public async Task<List<DiscussionBoard>> GetAllDiscussionBoardAsync()
        {
            return await _dataContext.DiscussionBoards.ToListAsync();
        }

        public async Task<List<DiscussionBoardComment>> GetAllDiscussionBoardCommentAsync()
        {
            return await _dataContext.DiscussionBoardComments.ToListAsync();
        }

        public async Task<List<DiscussionBoardPost>> GetAllDiscussionBoardPostAsync()
        {
            return await _dataContext.DiscussionBoardPost.ToListAsync();
        }

        public async Task<DiscussionBoard> GetDiscussionBoardByIdAsync(string id)
        {
            return await _dataContext.DiscussionBoards.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DiscussionBoardComment> GetDiscussionBoardCommentByIdAsync(string id)
        {
            return await _dataContext.DiscussionBoardComments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DiscussionBoardPost> GetDiscussionBoardPostByIdAsync(string id)
        {
            return await _dataContext.DiscussionBoardPost.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DiscussionBoard> UpdateDiscussionBoardAsync(string id, DiscussionBoard request)
        {
            var result = await GetDiscussionBoardByIdAsync(id);
            if (result != null)
            {
                result.Title = request.Title;                         
                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<DiscussionBoardComment> UpdateDiscussionBoardCommentAsync(string id, DiscussionBoardComment request)
        {
            var result = await GetDiscussionBoardCommentByIdAsync(id);
            if (result != null)
            {
                result.Content = request.Content;   
                result.CommentedDate = request.CommentedDate;                
            }
            return null;
        }

        public async Task<DiscussionBoardPost> UpdateDiscussionBoardPostAsync(string id, DiscussionBoardPost request)
        {
            var result = await GetDiscussionBoardPostByIdAsync(id);
            if (result != null)
            {
                result.Title = request.Title;
                result.Content = request.Content;                
                result.UpdatedDate = request.UpdatedDate;
                result.Content = request.Content;
                result.IsPublished = request.IsPublished;               
            }
            return null;
        }
    }
}
