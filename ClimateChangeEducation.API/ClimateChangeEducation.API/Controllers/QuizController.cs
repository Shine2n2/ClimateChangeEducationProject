using AutoMapper;
using ClimateChangeEducation.Domain.DTOs;
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

        #region Quiz controller
        // GET: api/<QuizController>
        [HttpGet]
        [Route("GetQuizzes")]
        public async Task<IActionResult> GetQuizzes()
        {
            try
            {
                var quizzes = await _quizRepo.GetAllQuizzesAsync();
                return Ok(_mapper.Map<List<Quiz>>(quizzes));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<QuizController>/5
        [HttpGet]
        [Route("GetQuizById/{id}")]
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

        [HttpGet]
        [Route("GetQuestionByQuizId/{id}")]
        public async Task<IActionResult> GetQuestionByQuizId([FromRoute] string quizId)
        {
            try
            {
                var result = await _quizRepo.GetQuestionByQuizIdAsync(quizId);
                return Ok(result);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        [HttpGet]
        [Route("GetAnswerByQuestionId/{questionId}")]
        public async Task<IActionResult> GetAnswerByQuestionId([FromRoute] string questionId)
        {
            try
            {
                var result = await _quizRepo.GetAnswerByQuestionIdAsync(questionId);
                return Ok(result);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }





        [HttpGet]
        [Route("GetQuizByCourseId/{id}")]
        public async Task<IActionResult> GetQuizByCourseId([FromRoute] string id)
        {
            try
            {
                var result = await _quizRepo.GetQuizByCourseIdAsync(id);
                return Ok(result);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<QuizController>
        [HttpPost]
        [Route("CreateQuiz")]
        public async Task<IActionResult> CreateQuiz([FromBody] QuizDTO request)
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
        [HttpPut]
        [Route("UpdateQuiz/{id}")]
        public async Task<IActionResult> UpdateQuiz([FromRoute] string id, [FromBody] QuizDTO request)
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
        [HttpDelete]
        [Route("DeleteQuiz/{id}")]
        public async Task<IActionResult> DeleteQuiz([FromRoute] string id)
        {
            try
            {
                if (await _quizRepo.ExistsQuizAsync(id))
                {
                    var result = await _quizRepo.DeleteQuizAsync(id);
                    return Ok(_mapper.Map<Quiz>(result));
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        #endregion

        #region Quiz Question endpoint

        [HttpGet]
        [Route("GetQuizQuestions")]
        public async Task<IActionResult> GetQuizQuestions()
        {
            try
            {
                var quizzes = await _quizRepo.GetAllQuizzesAsync();
                return (Ok(_mapper.Map<List<QuizQuestion>>(quizzes)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<QuizController>/5
        [HttpGet]
        [Route("GetQuizQuestionById/{id}")]
        public async Task<IActionResult> GetQuizQuestionById([FromRoute] string id)
        {
            try
            {
                var result = await _quizRepo.GetQuizQuestionByIdAsync(id);
                return Ok(_mapper.Map<QuizQuestion>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<QuizController>
        [HttpPost]
        [Route("CreateQuizQuestion")]
        public async Task<IActionResult> CreateQuizQuestion([FromBody] QuizQuestionDTO request)
        {
            try
            {
                var quiz = await _quizRepo.CreateQuizQuestionAsync(_mapper.Map<QuizQuestion>(request));
                return Ok(quiz);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // PUT api/<QuizController>/5
        [HttpPut]
        [Route("UpdateQuizQuestion/{id}")]
        public async Task<IActionResult> UpdateQuiz([FromRoute] string id, [FromBody] QuizQuestionDTO request)
        {
            try
            {
                if (await _quizRepo.ExistsQuizQuestionAsync(id))
                {
                    // Update Details
                    var updated = await _quizRepo.UpdateQuizQuestionAsync(id, _mapper.Map<QuizQuestion>(request));
                    if (updated != null)
                    {
                        return Ok(_mapper.Map<QuizQuestion>(updated));
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
        [HttpDelete]
        [Route("DeleteQuestion/{id}")]
        public async Task<IActionResult> DeleteQuizQuestion([FromRoute] string id)
        {
            try
            {
                if (await _quizRepo.ExistsQuizQuestionAsync(id))
                {
                    var result = await _quizRepo.DeleteQuizQuestionAsync(id);
                    return Ok(_mapper.Map<Quiz>(result));
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }


        #endregion

        #region Quiz Question Answer

        [HttpGet]
        [Route("GetQuizQuestionAnswers")]
        public async Task<IActionResult> GetQuestionAnswers()
        {
            try
            {
                var answers = await _quizRepo.GetAllQuestionAnswersAsync();
                return (Ok(_mapper.Map<List<QuestionAnswer>>(answers)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<QuizController>/5
        [HttpGet]
        [Route("GetQuestionAnswerById/{id}")]
        public async Task<IActionResult> GetQuestionAnswerById([FromRoute] string id)
        {
            try
            {
                var result = await _quizRepo.GetQuizQuestionAnswerByIdAsync(id);
                return Ok(_mapper.Map<QuestionAnswer>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<QuizController>
        [HttpPost]
        [Route("CreateQuestionAnswer")]
        public async Task<IActionResult> CreateQuestionAnswer([FromBody] QuestionAnswerDTO request)
        {
            try
            {
                var answer = await _quizRepo.CreateQuestionAnswerAsync(_mapper.Map<QuestionAnswer>(request));
                return Ok(answer);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // PUT api/<QuizController>/5
        [HttpPut]
        [Route("UpdateQuestionAnswer/{id}")]
        public async Task<IActionResult> UpdateQuestionAnswer([FromRoute] string id, [FromBody] QuestionAnswerDTO request)
        {
            try
            {
                if (await _quizRepo.ExistsQuestionAnswerAsync(id))
                {
                    // Update Details
                    var updated = await _quizRepo.UpdateQuestionAnswerAsync(id, _mapper.Map<QuestionAnswer>(request));
                    if (updated != null)
                    {
                        return Ok(_mapper.Map<QuestionAnswer>(updated));
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
        [HttpDelete]
        [Route("DeleteQuestionAnswer/{id}")]
        public async Task<IActionResult> DeleteQuestionAnswer([FromRoute] string id)
        {
            try
            {
                if (await _quizRepo.ExistsQuestionAnswerAsync(id))
                {
                    var result = await _quizRepo.DeleteQuestionAnswerAsync(id);
                    return Ok(_mapper.Map<QuestionAnswer>(result));
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        #endregion
    }
}
