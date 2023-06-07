using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCategoryController : ControllerBase
    {
        private readonly IArticleRepository _articleRepo;


        public ArticleCategoryController(IArticleRepository articleRepo)
        {
            _articleRepo = articleRepo;
        }
        // GET: api/<ArticleCategoryController>
        [HttpGet]
        public async Task<IActionResult> GetArticleCategories()
        {
            var articles = await _articleRepo.GetAllArticleAsync();

            //return Ok(mapper.Map<List<Student>>(students));
            //return new string[] { "value1", "value2" };
            return (Ok(articles));
        }

        // GET api/<ArticleCategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArticleCategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArticleCategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticleCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
