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
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IActionResult> GetSchools()
        {
            try
            {
                var students = await _studentRepo.GetAllStudentAsync();
                return (Ok(_mapper.Map<List<Student>>(students)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById([FromRoute] string id)
        {
            try
            {
                var result = await _studentRepo.GetStudentByIdAsync(id);
                return Ok(_mapper.Map<Student>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequestDTO request)
        {
            try
            {
                var student = await _studentRepo.CreateStudentAsync(_mapper.Map<Student>(request));
                return Ok(student);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] string id, [FromBody] StudentRequestDTO request)
        {
            try
            {
                if (await _studentRepo.ExistsStudentAsync(id))
                {
                    // Update Details
                    var updated = await _studentRepo.UpdateStudentAsync(id, _mapper.Map<Student>(request));
                    if (updated != null)
                    {
                        return Ok(_mapper.Map<School>(updated));
                    }
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool([FromRoute] string id)
        {
            try
            {
                if (await _studentRepo.ExistsStudentAsync(id))
                {
                    var result = await _studentRepo.DeleteStudent(id);
                    return Ok(_mapper.Map<Student>(result));
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
