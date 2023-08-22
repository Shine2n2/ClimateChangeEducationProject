using AutoMapper;
using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsRepository _contactUsRepo;
        private readonly IMapper _mapper;

        public ContactUsController(IContactUsRepository contactUsRepo, IMapper mapper)
        {
            _contactUsRepo = contactUsRepo;
            _mapper = mapper;
        }



        // GET: api/<ContactUsController>
        [HttpGet("GetMessages")]
        public async Task<IActionResult> GetContactMessages()
        {
            try
            {
                var contactUsMsgs = await _contactUsRepo.GetAllContactMsgAsync();
                return (Ok(_mapper.Map<List<ContactUs>>(contactUsMsgs)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ContactUsController>/5
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetContactMsgsById(string id)
        {
            try
            {
                var result = await _contactUsRepo.GetContactMsgsByIdAsync(id);
                return Ok(_mapper.Map<ContactUs>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        [HttpGet]
        [Route("GetByEmail/{email}")]
        public async Task<IActionResult> GetContactMsgsByEmail(string email)
        {
            try
            {
                var result = await _contactUsRepo.GetContactMsgsByEmailAsync(email);
                return Ok(_mapper.Map<ContactUs>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<ContactUsController>
        [HttpPost("create-messages")]
        public async Task<IActionResult> CreateContactUsMessage([FromBody] ContactUsDTO request)
        {
            try
            {
                var result = await _contactUsRepo.CreateContactMsgAsync(_mapper.Map<ContactUs>(request));
                return Ok(result);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

       

        // DELETE api/<ContactUsController>/5
        [HttpDelete]
        [Route("DeleteById/{id}")]
        public async Task<IActionResult> DeleteContactMsgById(string id)
        {
            try
            {
                if (await _contactUsRepo.ExistsContactMsgAsync(id))
                {
                    var contactUsMsg = await _contactUsRepo.DeleteContactMsg(id);
                    return Ok(_mapper.Map<ContactUs>(contactUsMsg));
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteByEmail/{email}")]
        public async Task<IActionResult> DeleteContactMsgsByEmail(string email)
        {
            try
            {
                if (await _contactUsRepo.ExistsContactMsgByEmailAsync(email))
                {
                    var contactUsMsg = await _contactUsRepo.DeleteContactMsgByemail(email);
                    return Ok(_mapper.Map<ContactUs>(contactUsMsg));
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
