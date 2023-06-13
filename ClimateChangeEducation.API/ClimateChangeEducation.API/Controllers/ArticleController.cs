using AutoMapper;
using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Interfaces;
using ClimateChangeEducation.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepo;
        private readonly IMapper _mapper;

        public ArticleController(IArticleRepository articleRepo, IMapper mapper)
        {
            _articleRepo = articleRepo;
            _mapper = mapper;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            try
            {
                var articles = await _articleRepo.GetAllArticleAsync();
                return (Ok(_mapper.Map<List<Article>>(articles)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleById(string id)
        {
            try
            {
                var result = await _articleRepo.GetArticleByIdAsync(id);
                return Ok(_mapper.Map<Article>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<ArticleController>
        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] ArticleDTO request)
        {
            try
            {
                var article = await _articleRepo.CreateArticleAsync(_mapper.Map<Article>(request));
                return Ok(article);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle([FromRoute]string id, [FromBody] Article request)
        {
            try
            {
                if (await _articleRepo.ExistsArticleAsync(id))
                {
                    // Update Details
                    var updatedArticle = await _articleRepo.UpdateArticleAsync(id, _mapper.Map<Article>(request));
                    if (updatedArticle != null)
                    {
                        return Ok(_mapper.Map<Student>(updatedArticle));
                    }
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle([FromRoute] string id)
        {
            try
            {
                if (await _articleRepo.ExistsArticleAsync(id))
                {
                    var article = await _articleRepo.DeleteArticle(id);
                    return Ok(_mapper.Map<ArticleCategory>(article));
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }
    }
}
