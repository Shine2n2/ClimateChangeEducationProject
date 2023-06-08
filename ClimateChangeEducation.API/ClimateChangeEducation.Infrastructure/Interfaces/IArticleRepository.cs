using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Interfaces
{
    public interface IArticleRepository
    {
        //Article repo interface
        Task<List<Article>> GetAllArticleAsync();
        Task<Article> GetArticleByIdAsync(string id);
        Task<Article> CreateArticleAsync(Article article);
        Task<Article> UpdateArticleAsync(string articleId, Article request);
        Task<bool> DeleteArticle(string request);

        //article category repo
        Task<List<ArticleCategory>> GetAllArticleCategoryAsync();
        Task<ArticleCategory> GetArticleCategoryByIdAsync(string id);
        Task<ArticleCategory> CreateArticleCategoryAsync(ArticleCategory articleCategory);
        Task<ArticleCategory> UpdateArticleCategoryAsync(string categoryId, ArticleCategory request);
        Task<bool> DeleteArticleCategory(string request);
        Task<bool> ExistsArticleCategoryAsync(string id);        
        Task<bool> ExistsArticleAsync(string id);        
    }
}
