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
        public async Task<IActionResult> GetQuizzes()
        {
            try
            {
                var quizzes = await _quizRepo.GetAllQuizzesAsync();
                return (Ok(_mapper.Map<List<Quiz>>(quizzes)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<QuizController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizById([FromRoute] string id)
        {
            try
            {
                var result = await _quizRepo.GetQuizByIdAsync(id);
                return Ok(_mapper.Map<Quiz>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<QuizController>
        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody] Quiz request)
        {
            try
            {
                var quiz = await _quizRepo.CreateQuizAsync(_mapper.Map<Quiz>(request));
                return Ok(quiz);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // PUT api/<QuizController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuiz([FromRoute] string id, [FromBody] Quiz request)
        {
            try
            {
                if (await _quizRepo.ExistsQuizAsync(id))
                {
                    // Update Details
                    var updated = await _quizRepo.UpdateQuizAsync(id, _mapper.Map<Quiz>(request));
                    if (updated != null)
                    {
                        return Ok(_mapper.Map<Quiz>(updated));
                    }
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // DELETE api/<QuizController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz([FromRoute] string id)
        {
            try
            {
                if (await _quizRepo.ExistsQuizAsync(id))
                {
                    var result = await _quizRepo.DeleteQuiz(id);
                    return Ok(_mapper.Map<Quiz>(result));
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
