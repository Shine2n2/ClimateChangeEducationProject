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
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepo;
        private readonly IMapper _mapper;

        public SchoolController(ISchoolRepository schoolRepo, IMapper mapper)
        {
            _schoolRepo = schoolRepo;
            _mapper = mapper;
        }

        // GET: api/<SchoolController>
        [HttpGet]
        [Route("{GetSchools}")]
        public async Task<IActionResult> GetSchools()
        {
            try
            {
                var schools = await _schoolRepo.GetAllSchoolAsync();
                return (Ok(_mapper.Map<List<School>>(schools)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<SchoolController>/5
        [HttpGet]
        [Route("GetSchoolById/{id}")]
        public async Task<IActionResult> GetSchoolById([FromRoute] string id)
        {
            try
            {
                var result = await _schoolRepo.GetSchoolByIdAsync(id);
                return Ok(_mapper.Map<School>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }


        [HttpGet]
        [Route("GetSchoolBySchoolCode/{schoolCode}")]
        public async Task<IActionResult> GetSchoolBySchoolCode(string schoolCode)
        {
            try
            {
                var result = await _schoolRepo.GetSchoolBySchoolCodeAsync(schoolCode);
                return Ok(_mapper.Map<School>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<SchoolController>
        [HttpPost]
        [Route("CreateSchool")]
        public async Task<IActionResult> CreateSchool([FromBody] SchoolRequestDTO request)
        {
            try
            {
                var school = await _schoolRepo.CreateSchoolAsync(_mapper.Map<School>(request));
                return Ok(school);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // PUT api/<SchoolController>/5
        [HttpPut]
        [Route("UpdateSchool/{id}")]
        public async Task<IActionResult> UpdateSchool([FromRoute] string id, [FromBody] SchoolRequestDTO request)
        {
            try
            {
                if (await _schoolRepo.ExistsSchoolAsync(id))
                {
                    // Update Details
                    var updated = await _schoolRepo.UpdateSchoolAsync(id, _mapper.Map<School>(request));
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

        // DELETE api/<SchoolController>/5
        [HttpDelete]
        [Route("DeleteSchool/{id}")]
        public async Task<IActionResult> DeleteSchool([FromRoute] string id)
        {
            try
            {
                if (await _schoolRepo.ExistsSchoolAsync(id))
                {
                    var result = await _schoolRepo.DeleteSchoolAsync(id);
                    return Ok(_mapper.Map<School>(result));
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
