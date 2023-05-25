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
        Task<List<Article>> CreateArticleAsync(Article article);
        Task<bool> UpdateArticleAsync(Article request);
        Task<bool> DeleteArticle(Article request);

        //article category repo
        Task<List<ArticleCategory>> GetAllArticleCategoryAsync();
        Task<ArticleCategory> GetArticleCategoryByIdAsync(string id);
        Task<List<ArticleCategory>> CreateArticleCategoryAsync(ArticleCategory articleCategory);
        Task<bool> UpdateArticleCategoryAsync(ArticleCategory request);
        Task<bool> DeleteArticleCategory(ArticleCategory request);
    }
}
