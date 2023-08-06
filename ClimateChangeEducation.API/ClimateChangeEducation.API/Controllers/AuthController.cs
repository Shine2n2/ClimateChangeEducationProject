using ClimateChangeEducation.Application.Interfaces;
using ClimateChangeEducation.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {

        private readonly IUserService _userService;


        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("RegisterStudentUser")]
        public async Task<ActionResult> RegisterStudentAsync(StudentRequestDTO model)
        {
            try
            {
                var result = await _userService.RegisterStudentAsync(model);
                return Ok(result);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }            
        }

        [HttpPost]
        [Route("RegisterTeacherUser")]
        public async Task<ActionResult> RegisterTeacherAsync(TeacherRequestDTO model)
        {           
            try
            {
                var result = await _userService.RegisterTeacherAsync(model);
                return Ok(result);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        [HttpPost]
        [Route("RegisterSchoolUser")]
        public async Task<ActionResult> RegisterSchoolAsync(SchoolRequestDTO model)
        {            
            try
            {
                var result = await _userService.RegisterSchoolAsync(model);
                return Ok(result);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }        
    }
}
