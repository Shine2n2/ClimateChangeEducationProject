using AutoMapper;
using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepo;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepository teacherRepo, IMapper mapper)
        {
            _teacherRepo = teacherRepo;
            _mapper = mapper;
        }
        // GET: api/<TeacherController>
        [HttpGet]
        public async Task<IActionResult> GetSchools()
        {
            try
            {
                var teachers = await _teacherRepo.GetAllTeacherAsync();
                return (Ok(_mapper.Map<List<Teacher>>(teachers)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById([FromRoute] string id)
        {
            try
            {
                var teacher = await _teacherRepo.GetTeacherByIdAsync(id);
                return Ok(_mapper.Map<Teacher>(teacher));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }


        [HttpGet("teachId")]
        public async Task<IActionResult> GetTeachIdDIS(string id)
        {
            try
            {
                var teacher = await _teacherRepo.GetTeacherByIdAsync(id);
                return Ok(_mapper.Map<Teacher>(teacher));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }



        // POST api/<TeacherController>
        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherRequestDTO request)
        {
            try
            {
                var teacher = await _teacherRepo.CreateTeacherAsync(_mapper.Map<Teacher>(request));
                return Ok(teacher);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher([FromRoute] string id, [FromBody] TeacherRequestDTO request)
        {
            try
            {
                if (await _teacherRepo.ExistsTeacherAsync(id))
                {
                    // Update Details
                    var updated = await _teacherRepo.UpdateTeacherAsync(id, _mapper.Map<Teacher>(request));
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

        [HttpPatch]
        [Route("UpdateTeacherPatch/{id}")]
        public async Task<IActionResult> UpdateTeacherPatch([FromRoute] string id, [FromBody] JsonPatchDocument request)
        {
            try
            {
                await _teacherRepo.UpdateTeacherPatchAsync(id, request);
                return Ok();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher([FromRoute] string id)
        {
            try
            {
                if (await _teacherRepo.ExistsTeacherAsync(id))
                {
                    var result = await _teacherRepo.DeleteTeacher(id);
                    return Ok(_mapper.Map<Teacher>(result));
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
