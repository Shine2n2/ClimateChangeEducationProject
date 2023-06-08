using AutoMapper;
using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscussionBoardController : ControllerBase
    {
        private readonly IDiscussionBoardRepository _discussionBoardRepo;
        private readonly IMapper _mapper;

        public DiscussionBoardController(IDiscussionBoardRepository discussionBoardRepo, IMapper mapper)
        {
            _discussionBoardRepo = discussionBoardRepo;
            _mapper = mapper;
        }
        // GET: api/<DiscussionBoardController>
        [HttpGet]
        public async Task<IActionResult> GetDiscussionBoards()
        {
            try
            {
                var discussionboards = await _discussionBoardRepo.GetAllDiscussionBoardAsync();
                return (Ok(_mapper.Map<List<DiscussionBoard>>(discussionboards)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<DiscussionBoardController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscussionBoardById([FromRoute] string id)
        {
            try
            {
                var result = await _discussionBoardRepo.GetDiscussionBoardByIdAsync(id);
                return Ok(_mapper.Map<DiscussionBoard>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<DiscussionBoardController>
        [HttpPost]
        public async Task<IActionResult> CreateDiscussionBoard([FromBody] DiscussionBoard request)
        {
            try
            {
                var discussionBoard = await _discussionBoardRepo.CreateDiscussionBoardAsync(_mapper.Map<DiscussionBoard>(request));
                return Ok(discussionBoard);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // PUT api/<DiscussionBoardController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiscussionBoard([FromRoute] string id, [FromBody] Course request)
        {
            try
            {
                if (await _discussionBoardRepo.ExistsDiscussionBoardAsync(id))
                {
                    // Update Details
                    var updated = await _discussionBoardRepo.UpdateDiscussionBoardAsync(id, _mapper.Map<DiscussionBoard>(request));
                    if (updated != null)
                    {
                        return Ok(_mapper.Map<Student>(updated));
                    }
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // DELETE api/<DiscussionBoardController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscussionBoard([FromRoute] string id)
        {
            try
            {
                if (await _discussionBoardRepo.ExistsDiscussionBoardAsync(id))
                {
                    var result = await _discussionBoardRepo.DeleteDiscussionBoard(id);
                    return Ok(_mapper.Map<Course>(result));
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
