using AutoMapper;
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

        // GET: api/<ContactUsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ContactUsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContactUsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ContactUsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactUsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
