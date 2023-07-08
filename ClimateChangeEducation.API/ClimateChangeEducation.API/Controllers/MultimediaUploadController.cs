using AutoMapper;
using ClimateChangeEducation.Infrastructure.Interfaces;
using ClimateChangeEducation.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultimediaUploadController : ControllerBase
    {

        private readonly ILocalImageStorageRepository _localStorageRepo;        
        private readonly IStudentRepository _studentRepo;        

        public MultimediaUploadController(ILocalImageStorageRepository localStorageRepo, IStudentRepository studentRepo)
        {
            _localStorageRepo = localStorageRepo;   
            _studentRepo = studentRepo;
        }

        [HttpPost]
        [Route("{id}/upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] string id, IFormFile profileImage)
        {
            try
            {
                var validExtensions = new List<string>
                {
                   ".jpeg",
                   ".png",
                   ".gif",
                   ".jpg"
                };

                if (profileImage != null && profileImage.Length > 0)
                {
                    string extension = Path.GetExtension(profileImage.FileName);
                    bool check = validExtensions.Contains(extension);
                    if (check)
                    {
                        var fileName = id + Path.GetExtension(profileImage.FileName);
                        var fileImagePath = await _localStorageRepo.UploadImg(profileImage, fileName);
                    }
                    return Ok("Upload Successful!");
                }
                return NotFound();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("{id}/upload-video")]
        public async Task<IActionResult> UploadVideo([FromRoute] string id, IFormFile videoFile)
        {
            try
            {
                var validExtensions = new List<string>
                {
                   ".mp4",
                   ".mkv",
                   ".avi"
                };

                if (videoFile != null && videoFile.Length > 0)
                {
                    var extension = Path.GetExtension(videoFile.FileName);
                    if (validExtensions.Contains(extension))
                    {
                        var fileName = id + Path.GetExtension(videoFile.FileName);
                        var fileImagePath = await _localStorageRepo.UploadVideo(videoFile, fileName);
                    }
                    return Ok("Upload Successful!");
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("{id}/upload-document")]
        public async Task<IActionResult> UploadDocument([FromRoute] string id, IFormFile documentFile)
        {
            try
            {
                var validExtensions = new List<string>
                {
                   ".pdf"                  
                };

                if (documentFile != null && documentFile.Length > 0)
                {
                    var extension = Path.GetExtension(documentFile.FileName);
                    if (validExtensions.Contains(extension))
                    {
                        var fileName = id + Path.GetExtension(documentFile.FileName);
                        var fileImagePath = await _localStorageRepo.UploadDocument(documentFile, fileName);
                    }
                    return Ok("Upload Successful!");
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
