using ClimateChangeEducation.Application.Interfaces;
using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Domain.Entities;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;



        public AuthController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
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


        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(TokenRequest model)
        {
            var result = await _userService.GetTokenAsync(model);
            return Ok(result);
        }

        [HttpPost]
        [Route("SendVerificationEmail")]
        public async Task<ActionResult> SendVerificationEmailAsync(EmailRequestDTO emailReq, string token)
        {
            try
            {
                var emailRq = new EmailRequest
                {
                    Subject = emailReq.Subject,
                    IsSuccessful = true,
                    Message= emailReq.Message,
                    ToEmail = emailReq.ToEmail
                };
                await _userService.SendVerificationEmailAsync(token, emailRq);
                return Ok(emailRq);
            }
            catch (Exception ex)
            {
               return BadRequest("Email not sent");
            }
        }

        [HttpPost("request-password-reset")]
        public async Task<IActionResult> RequestPasswordReset(EmailRequestDTO emailReq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(emailReq.ToEmail);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            // Generate JWT token for password reset
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Send password reset email
            var emailRq = new EmailRequest
            {
                Subject = emailReq.Subject,
                IsSuccessful = true,
                Message = emailReq.Message,
                ToEmail = emailReq.ToEmail
            };
            await _userService.SendVerificationEmailAsync(token, emailRq);
            return Ok("Message sent");          
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(EmailRequestDTO emailReq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var user = await _userManager.FindByEmailAsync(emailReq.ToEmail);
            //if (user == null)
            //{
            //    return BadRequest("User not found");
            //}

            //var result = "rr";//await _userManager.ResetPasswordAsync(user, emailReq..Token, emailReq.NewPassword);

            //if (!result.Succeeded)
            //{
            //    return BadRequest(result.Errors);
            //}

            return Ok(new { Message = "Password reset successful" });
        }
    }
}
