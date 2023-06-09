using AutoMapper;
using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClimateChangeEducation.API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository _quizRepo;
        private readonly IMapper _mapper;

        public QuizController(IQuizRepository quizRepo, IMapper mapper)
        {
            _quizRepo = quizRepo;
            _mapper = mapper;
        }
        // GET: api/<QuizController>
        [HttpGet]
        //public async Task<IActionResult> GetGetQuizzes()
        //{
        //    try
        //    {
        //       // var discussionboards = await _quizRepo..GetAllQuizzesAsync();
        //        //return (Ok(_mapper.Map<List<DiscussionBoard>>(discussionboards)));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        // GET api/<QuizController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QuizController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QuizController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuizController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
