using AutoMapper;
using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Interfaces;
using ClimateChangeEducation.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;



namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCategoryController : ControllerBase
    {
        private readonly IArticleRepository _articleRepo;
        private readonly IMapper _mapper;

        public ArticleCategoryController(IArticleRepository articleRepo, IMapper mapper)
        {
            _articleRepo = articleRepo;
            _mapper = mapper;
        }
        // GET: api/<ArticleCategoryController>
        [HttpGet]
        public async Task<IActionResult> GetArticleCategories()
        {
            try
            {
                var articles = await _articleRepo.GetAllArticleCategoryAsync();
                return Ok(_mapper.Map<List<ArticleCategory>>(articles));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }                               
        }

        // GET api/<ArticleCategoryController>/5
        [HttpGet("{id}")]        
        public async Task<IActionResult> GetArticleCategoryById([FromRoute] string id)
        {
            try
            {
                var result = await _articleRepo.GetArticleCategoryByIdAsync(id);
                return Ok(_mapper.Map<ArticleCategory>(result));               
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }
           
        // POST api/<ArticleCategoryController>
        [HttpPost]
        public async Task<IActionResult> CreateArticleCategory([FromBody] ArticleCategoryDTO request)
        {
            try
            {
                var articleCategory = await _articleRepo.CreateArticleCategoryAsync(_mapper.Map<ArticleCategory>(request));
                return Ok(articleCategory);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }            
        }

        // PUT api/<ArticleCategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticleCategory([FromRoute] string id, [FromBody] ArticleCategoryDTO request)
        {
            try
            {
                if (await _articleRepo.ExistsArticleCategoryAsync(id))
                {
                    // Update Details
                    var updatedCategory = await _articleRepo.UpdateArticleCategoryAsync(id, _mapper.Map<ArticleCategory>(request));

                    if (updatedCategory != null)
                    {
                        return Ok(_mapper.Map<Student>(updatedCategory));
                    }
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // DELETE api/<ArticleCategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticleCategory([FromRoute] string id)
        {
            try
            {                
                if (await _articleRepo.ExistsArticleCategoryAsync(id))
                {
                    var articleCategory = await _articleRepo.DeleteArticleCategory(id);
                    return Ok(_mapper.Map<ArticleCategory>(articleCategory));
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
