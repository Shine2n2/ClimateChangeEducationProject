using ClimateChangeEducation.Common.Configurations;
using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Repositories
{
    
    public class ArticleRepository : IArticleRepository
    {           

        public Task<List<Article>> CreateArticleAsync(Article article)
        {         
            throw new NotImplementedException();
        }

        public Task<List<ArticleCategory>> CreateArticleCategoryAsync(ArticleCategory articleCategory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteArticle(Article request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteArticleCategory(ArticleCategory request)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetAllArticleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleCategory>> GetAllArticleCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetArticleByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleCategory> GetArticleCategoryByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateArticleAsync(Article request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateArticleCategoryAsync(ArticleCategory request)
        {
            throw new NotImplementedException();
        }
    }
}
