using AutoMapper;
using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepo, IMapper mapper)
        {
            _courseRepo = courseRepo;
            _mapper = mapper;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            try
            {
                var courses = await _courseRepo.GetAllCoursesAsync();
                return (Ok(_mapper.Map<List<Course>>(courses)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById([FromRoute]string id)
        {
            try
            {
                var result = await _courseRepo.GetCourseByIdAsync(id);
                return Ok(_mapper.Map<Course>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] Course request)
        {
            try
            {
                var course = await _courseRepo.CreateCourseAsync(_mapper.Map<Course>(request));
                return Ok(course);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] string id, [FromBody] Course request)
        {
            try
            {
                if (await _courseRepo.ExistsCourseAsync(id))
                {
                    // Update Details
                    var updatedCourse = await _courseRepo.UpdateCourseAsync(id, _mapper.Map<Course>(request));
                    if (updatedCourse != null)
                    {
                        return Ok(_mapper.Map<Student>(updatedCourse));
                    }
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] string id)
        {
            try
            {
                if (await _courseRepo.ExistsCourseAsync(id))
                {
                    var course = await _courseRepo.DeleteCourse(id);
                    return Ok(_mapper.Map<Course>(course));
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
