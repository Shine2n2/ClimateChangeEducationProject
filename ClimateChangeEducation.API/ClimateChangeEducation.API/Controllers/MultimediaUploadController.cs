using AutoMapper;
using ClimateChangeEducation.Infrastructure.Interfaces;
using ClimateChangeEducation.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var validExtensions = new List<string>
            {
               ".jpeg",
               ".png",
               ".gif",
               ".jpg"
            };

            if (profileImage != null && profileImage.Length > 0)
            {
                var extension = Path.GetExtension(profileImage.FileName);
                if (validExtensions.Contains(extension))
                {
                    if (await _studentRepo.ExistsStudentAsync(id))
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);

                        var fileImagePath = await _localStorageRepo.UploadImg(profileImage, fileName);

                        if (await _studentRepo.UpdateProfileImage(id, fileImagePath))
                        {
                            return Ok(fileImagePath);
                        }

                        return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image");
                    }
                }
                return BadRequest("This is not a valid Image format");
            }
            return NotFound();
        }

        [HttpPost]
        [Route("{id}/upload-video")]
        public async Task<IActionResult> UploadVideo([FromRoute] string id, IFormFile videoFile)
        {
            var validExtensions = new List<string>
            {
               ".jpeg",
               ".png",
               ".gif",
               ".jpg"
            };

            if (videoFile != null && videoFile.Length > 0)
            {
                var extension = Path.GetExtension(videoFile.FileName);
                if (validExtensions.Contains(extension))
                {
                    if (await _studentRepo.ExistsStudentAsync(id))
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(videoFile.FileName);

                        var fileImagePath = await _localStorageRepo.UploadImg(videoFile, fileName);

                        if (await _studentRepo.UpdateProfileImage(id, fileImagePath))
                        {
                            return Ok(fileImagePath);
                        }

                        return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image");
                    }
                }
                return BadRequest("This is not a valid Image format");
            }
            return NotFound();
        }
    }
}
