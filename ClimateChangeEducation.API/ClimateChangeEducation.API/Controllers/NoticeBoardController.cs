using AutoMapper;
using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticeBoardController : ControllerBase
    {
        private readonly INoticeBoardRepository _noticeRepo;    
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public NoticeBoardController(INoticeBoardRepository noticeRepo, IMapper mapper)
        {
            _noticeRepo = noticeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllNotices")]
        public async Task<IActionResult> GetAllNotices()
        {
            try
            {
                var contactUsMsgs = await _noticeRepo.GetAllNoticesAsync();
                return (Ok(_mapper.Map<List<NoticeBoard>>(contactUsMsgs)));
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ContactUsController>/5
        [HttpGet]
        [Route("GetNoticeById/{id}")]
        public async Task<IActionResult> GetNoticeById(string id)
        {
            try
            {
                var result = await _noticeRepo.GetNoticeByIdAsync(id);
                return Ok(_mapper.Map<NoticeBoard>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllPublishedNotice")]
        public async Task<IActionResult> GetAllPublishedNotice()
        {
            try
            {
                var result = await _noticeRepo.GetAllPublishedNoticesAsync();
                return Ok(_mapper.Map<NoticeBoard>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllPublishedNoticeBySchoolId/{schoolId}")]
        public async Task<IActionResult> GetPublishedNoticesBySchoolId(string schoolId)
        {
            try
            {
                var result = await _noticeRepo.GetAllPublishedNoticesBySchoolIdAsync(schoolId);
                return Ok(_mapper.Map<NoticeBoard>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllNoticeBySchoolId/{schoolId}")]
        public async Task<IActionResult> GetNoticesBySchoolId(string schoolId)
        {
            try
            {
                var result = await _noticeRepo.GetNoticesBySchoolIdAsync(schoolId);
                return Ok(_mapper.Map<NoticeBoard>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }


        // POST api/<ContactUsController>
        [HttpPost]
        [Route("CreateNotice")]
        public async Task<IActionResult> CreateNotice([FromBody] NoticeBoardDTO request)
        {
            try
            {
                var result = await _noticeRepo.CreateNoticeAsync(_mapper.Map<NoticeBoard>(request));
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
                if (await _noticeRepo.ExistsNoticeAsync(id))
                {
                    var notice = await _noticeRepo.DeleteNotice(id);
                    return Ok(_mapper.Map<NoticeBoard>(notice));
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
