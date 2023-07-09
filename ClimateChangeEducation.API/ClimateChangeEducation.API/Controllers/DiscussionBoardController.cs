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
    public class DiscussionBoardController : ControllerBase
    {
        private readonly IDiscussionBoardRepository _discussionBoardRepo;
        private readonly IMapper _mapper;

        public DiscussionBoardController(IDiscussionBoardRepository discussionBoardRepo, IMapper mapper)
        {
            _discussionBoardRepo = discussionBoardRepo;
            _mapper = mapper;
        }

        #region Discussion board controller
        // GET: api/<DiscussionBoardController>
        [HttpGet]
        [Route("GetDiscussionBoard")]
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
        [HttpGet]
        [Route("GetDiscussionBoardById/{id}")]
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
        [Route("CreateDiscussionBoard")]
        public async Task<IActionResult> CreateDiscussionBoard([FromBody] DiscussionBoardDTO request)
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
        [HttpPut]
        [Route("UpdateDiscussionBoard/{id}")]
        public async Task<IActionResult> UpdateDiscussionBoard([FromRoute] string id, [FromBody] DiscussionBoardDTO request)
        {
            try
            {
                if (await _discussionBoardRepo.ExistsDiscussionBoardAsync(id))
                {
                    // Update Details
                    var updated = await _discussionBoardRepo.UpdateDiscussionBoardAsync(id, _mapper.Map<DiscussionBoard>(request));
                    if (updated != null)
                    {
                        return Ok(_mapper.Map<DiscussionBoard>(updated));
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
        [HttpDelete]
        [Route("DeleteDiscussionBoard/{id}")]
        public async Task<IActionResult> DeleteDiscussionBoard([FromRoute] string id)
        {
            try
            {
                if (await _discussionBoardRepo.ExistsDiscussionBoardAsync(id))
                {
                    var result = await _discussionBoardRepo.DeleteDiscussionBoard(id);
                    return Ok(_mapper.Map<DiscussionBoardPost>(result));
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        #endregion

        #region Discussion post controller

        [HttpGet]
        [Route("GetDiscussionBoardPosts")]
        public async Task<IActionResult> GetDiscussionBoardPosts()
        {
            try
            {
                var discussionboardPosts = await _discussionBoardRepo.GetAllDiscussionBoardPostAsync();
                return (Ok(_mapper.Map<List<DiscussionBoardPost>>(discussionboardPosts)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<DiscussionBoardController>/5
        [HttpGet]
        [Route("GetDiscussionBoardPostById/{id}")]
        public async Task<IActionResult> GetDiscussionBoardPostById([FromRoute] string id)
        {
            try
            {
                var result = await _discussionBoardRepo.GetDiscussionBoardPostByIdAsync(id);
                return Ok(_mapper.Map<DiscussionBoardPost>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<DiscussionBoardController>
        [HttpPost]
        [Route("CreateDiscussionBoardPost")]
        public async Task<IActionResult> CreateDiscussionBoardPost([FromBody] DiscussionBoardPostDTO request)
        {
            try
            {
                var post = await _discussionBoardRepo.CreateDiscussionBoardPostAsync(_mapper.Map<DiscussionBoardPost>(request));
                return Ok(post);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // PUT api/<DiscussionBoardController>/5
        [HttpPut]
        [Route("UpdateDiscussionBoardPost/{id}")]
        public async Task<IActionResult> UpdateDiscussionBoardPost([FromRoute] string id, [FromBody] DiscussionBoardPostDTO request)
        {
            try
            {
                if (await _discussionBoardRepo.ExistsDiscussionBoardPostAsync(id))
                {
                    // Update Details
                    var updated = await _discussionBoardRepo.UpdateDiscussionBoardPostAsync(id, _mapper.Map<DiscussionBoardPost>(request));
                    if (updated != null)
                    {
                        return Ok(_mapper.Map<DiscussionBoardPost>(updated));
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
        [HttpDelete]
        [Route("DeleteDiscussionBoardPost/{id}")]
        public async Task<IActionResult> DeleteDiscussionBoardPosts([FromRoute] string id)
        {
            try
            {
                if (await _discussionBoardRepo.ExistsDiscussionBoardPostAsync(id))
                {
                    var result = await _discussionBoardRepo.DeleteDiscussionBoardPost(id);
                    return Ok(_mapper.Map<DiscussionBoardPost>(result));
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }
        #endregion

        #region Discussion borad comment

        [HttpGet]
        [Route("GetDiscussionBoardComments")]
        public async Task<IActionResult> GetDiscussionBoardComments()
        {
            try
            {
                var comments = await _discussionBoardRepo.GetAllDiscussionBoardCommentAsync();
                return (Ok(_mapper.Map<List<DiscussionBoardComment>>(comments)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<DiscussionBoardController>/5
        [HttpGet]
        [Route("GetDiscussionBoardCommentById/{id}")]
        public async Task<IActionResult> GetDiscussionBoardCommentById([FromRoute] string id)
        {
            try
            {
                var result = await _discussionBoardRepo.GetDiscussionBoardCommentByIdAsync(id);
                return Ok(_mapper.Map<DiscussionBoardComment>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<DiscussionBoardController>
        [HttpPost]
        [Route("CreateDiscussionBoardComment")]
        public async Task<IActionResult> CreateDiscussionBoardComment([FromBody] DiscussionBoardCommentDTO request)
        {
            try
            {
                var comment = await _discussionBoardRepo.CreateDiscussionBoardCommentAsync(_mapper.Map<DiscussionBoardComment>(request));
                return Ok(comment);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // PUT api/<DiscussionBoardController>/5
        [HttpPut]
        [Route("UpdateDiscussionBoardComment/{id}")]
        public async Task<IActionResult> UpdateDiscussionBoardComment([FromRoute] string id, [FromBody] DiscussionBoardCommentDTO request)
        {
            try
            {
                if (await _discussionBoardRepo.ExistsDiscussionBoardPostAsync(id))
                {
                    // Update Details
                    var updated = await _discussionBoardRepo.UpdateDiscussionBoardCommentAsync(id, _mapper.Map<DiscussionBoardComment>(request));
                    if (updated != null)
                    {
                        return Ok(_mapper.Map<DiscussionBoardPost>(updated));
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
        [HttpDelete]
        [Route("DeleteDiscussionBoardComment/{id}")]
        public async Task<IActionResult> DeleteDiscussionBoardComment([FromRoute] string id)
        {
            try
            {
                if (await _discussionBoardRepo.ExistsDiscussionBoardPostAsync(id))
                {
                    var result = await _discussionBoardRepo.DeleteDiscussionBoardPost(id);
                    return Ok(_mapper.Map<DiscussionBoardPost>(result));
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }
        #endregion
    }
}
