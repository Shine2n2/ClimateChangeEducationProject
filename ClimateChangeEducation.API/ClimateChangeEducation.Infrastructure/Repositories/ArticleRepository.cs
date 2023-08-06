using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Data;
using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ClimateChangeEducation.Infrastructure.Repositories
{

    public class ArticleRepository : IArticleRepository
    {
        private readonly ClimateDataContext _dataContext;
        public ArticleRepository(ClimateDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Article> CreateArticleAsync(Article articleReq)
        {
            var result = new Article();
            result.ArticleCategoryId = articleReq.ArticleCategoryId;
            var article = await _dataContext.Articles.AddAsync(result); 
            await _dataContext.SaveChangesAsync();
            return article.Entity;
        }

        public async Task<ArticleCategory> CreateArticleCategoryAsync(ArticleCategory articleCategory)
        {
            var result = await _dataContext.ArticleCategories.AddAsync(articleCategory);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteArticle(string request)
        {
            var result = await GetArticleByIdAsync(request);
            if (result != null)
            {
                _dataContext.Articles.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteArticleCategory(string request)
        {
            var result = await GetArticleCategoryByIdAsync(request);
            if (result != null)
            {
                _dataContext.ArticleCategories.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Article>> GetAllArticleAsync()
        {            
            return await _dataContext.Articles.Include(article => article.Category).ToListAsync();
        }

        public async Task<List<ArticleCategory>> GetAllArticleCategoryAsync()
        {            
            return await _dataContext.ArticleCategories.ToListAsync();
        }
              

        public async Task<Article> GetArticleByIdAsync(string id)
        {
            return await _dataContext.Articles
                .Include(article => article.Category).FirstOrDefaultAsync(x => x.Id == id);
            //return await _dataContext.Articles.Include(nameof(ArticleCategory)).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ArticleCategory> GetArticleCategoryByIdAsync(string id)
        {
            return await _dataContext.ArticleCategories.FirstOrDefaultAsync(x => x.ArticleCategoryId==id);            
        }

        public async Task<Article> UpdateArticleAsync(string articleId, Article request)
        {
            var existingArticle = await GetArticleByIdAsync(articleId);
            if (existingArticle != null)
            {
                existingArticle.Title = request.Title;
                existingArticle.Description = request.Description;
                existingArticle.Content = request.Content;
                existingArticle.MediaUrl = request.MediaUrl;
                existingArticle.ArticleCategoryId = request.ArticleCategoryId;                

                await _dataContext.SaveChangesAsync();
                return existingArticle;
            }
            return null;            
        }

        public async Task<ArticleCategory> UpdateArticleCategoryAsync(string categoryId, ArticleCategory request)
        {
            var existingArticleCate = await GetArticleCategoryByIdAsync(categoryId);
            if (existingArticleCate != null)
            {
                existingArticleCate.Title = request.Title;
                existingArticleCate.Description = request.Description;           

                await _dataContext.SaveChangesAsync();
                return existingArticleCate;
            }
            return null;
        }

        public async Task<bool> ExistsArticleCategoryAsync(string id)
        {
            return await _dataContext.ArticleCategories.AnyAsync(x => x.ArticleCategoryId == id);
        }
        
        public async Task<bool> ExistsArticleAsync(string id)
        {
            return await _dataContext.Articles.AnyAsync(x => x.ArticleCategoryId == id);
        }
    }
}
