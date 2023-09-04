using AutoMapper;
using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepo;
        private readonly IMapper _mapper;

        public EnrollmentController(IEnrollmentRepository enrollmentRepo, IMapper mapper)
        {
            _enrollmentRepo = enrollmentRepo;
            _mapper = mapper;
        }
        // GET: api/<CourseEnrollmentController>
        [HttpGet]
        [Route("CourseEnrollment")]
        public async Task<IActionResult> GetCourseEnrollments()
        {
            try
            {
                var coursesEnrolled = await _enrollmentRepo.GetAllCourseEnrollmentAsync();
                return (Ok(_mapper.Map<List<CourseEnrollment>>(coursesEnrolled)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CourseEnrollmentController>/5
        [HttpGet]
        [Route("CourseEnrollment/{id}")]
        public async Task<IActionResult> GetCourseEnrollmentById(string id)
        {
            try
            {
                var result = await _enrollmentRepo.GetCourseEnrollmentByIdAsync(id);
                return Ok(_mapper.Map<CourseEnrollment>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        //// GET api/<CourseEnrollmentController>/4


        //// POST api/<CourseEnrollmentController>
        [HttpPost]
        [Route("AddCourseEnrollment")]
        public async Task<IActionResult> CreateCourseEnrollment([FromBody] CourseEnrollmentDTO request)
        {
            try
            {
                var courseEnrollment = await _enrollmentRepo.CreateCourseEnrollmentAsync(_mapper.Map<CourseEnrollment>(request));
                return Ok(courseEnrollment);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        //// PUT api/<CourseEnrollmentController>/5
        [HttpPut]
        [Route("UpdateCourseEnrollment/{id}")]
        public async Task<IActionResult> UpdateCourseEnrollment([FromRoute] string id, [FromBody] CourseEnrollmentDTO request)
        {
            try
            {
                if (await _enrollmentRepo.ExistsCourseEnrollmentAsync(id))
                {
                    // Update Details
                    var updatedCourseEnrollment = await _enrollmentRepo.UpdateCourseEnrollmentAsync(id, _mapper.Map<CourseEnrollment>(request));
                    if (updatedCourseEnrollment != null)
                    {
                        return Ok(_mapper.Map<CourseEnrollment>(updatedCourseEnrollment));
                    }
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        //// DELETE api/<CourseEnrollmentController>/5
        [HttpDelete]
        [Route("DeleteCourseEnrollment/{id}")]
        public async Task<IActionResult> DeleteCourseEnrollment([FromRoute] string id)
        {
            try
            {
                if (await _enrollmentRepo.ExistsCourseEnrollmentAsync(id))
                {
                    var result = await _enrollmentRepo.DeleteCourseEnrollment(id);
                    return Ok(_mapper.Map<CourseEnrollment>(result));
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        //// GET api/<QuizEnrollmentController>/4
        [HttpGet]
        [Route("QuizEnrollment/{studentId}")]
        public async Task<IActionResult> GetQuizEnrollmentByStudentId(string studentId)
        {
            try
            {
                var result = await _enrollmentRepo.GetQuizEnrollmentByStudentIdAsync(studentId);
                return Ok(_mapper.Map<QuizEnrollment>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        //// GET: api/<QuizEnrollmentController>
        [HttpGet]
        [Route("QuizEnrollment")]
        public async Task<IActionResult> GetQuizEnrollments()
        {
            try
            {
                var quizzesEnrolled = await _enrollmentRepo.GetAllQuizEnrollmentAsync();
                return (Ok(_mapper.Map<List<QuizEnrollment>>(quizzesEnrolled)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// GET api/<QuizEnrollmentController>/5
        [HttpGet]
        [Route("QuizEnrollment/{id}")]
        public async Task<IActionResult> GetQuizEnrollmentById(string id)
        {
            try
            {
                var result = await _enrollmentRepo.GetQuizEnrollmentByIdAsync(id);
                return Ok(_mapper.Map<QuizEnrollment>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }


        //// POST api/<QuizEnrollmentController>
        [HttpPost]
        [Route("AddQuizEnrollment")]
        public async Task<IActionResult> CreateQuizEnrollment([FromBody] QuizEnrollmentDTO request)
        {
            try
            {
                var quizEnrollment = await _enrollmentRepo.CreateQuizEnrollmentAsync(_mapper.Map<QuizEnrollment>(request));
                return Ok(quizEnrollment);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        //// PUT api/<QuizEnrollmentController>/5
        [HttpPut]
        [Route("UpdateQuizEnrollment/{id}")]
        public async Task<IActionResult> UpdateQuizEnrollment([FromRoute] string id, [FromBody] QuizEnrollmentDTO request)
        {
            try
            {
                if (await _enrollmentRepo.ExistsCourseEnrollmentAsync(id))
                {
                    // Update Details
                    var updatedQuizEnrollment = await _enrollmentRepo.UpdateQuizEnrollmentAsync(id, _mapper.Map<QuizEnrollment>(request));
                    if (updatedQuizEnrollment != null)
                    {
                        return Ok(_mapper.Map<QuizEnrollment>(updatedQuizEnrollment));
                    }
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        [HttpPatch]
        [Route("UpdateQuizScorePatch/{studentId}")]
        public async Task<IActionResult> UpdateQuizScorePatch([FromRoute] string studentId, [FromBody] JsonPatchDocument request)
        {
            try
            {               
                await _enrollmentRepo.UpdateQuizScorePatchAsync(studentId, request);
                return Ok();                                                                    
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        //// DELETE api/<QuizEnrollmentController>/5
        [HttpDelete]
        [Route("DeleteEnrollment/{id}")]
        public async Task<IActionResult> DeleteQuizEnrollment([FromRoute] string id)
        {
            try
            {
                if (await _enrollmentRepo.ExistsQuizEnrollmentAsync(id))
                {
                    var result = await _enrollmentRepo.DeleteQuizEnrollment(id);
                    return Ok(_mapper.Map<QuizEnrollment>(result));
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
