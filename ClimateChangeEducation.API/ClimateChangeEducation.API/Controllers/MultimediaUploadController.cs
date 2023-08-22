using AutoMapper;
using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Infrastructure.Helpers;
using ClimateChangeEducation.Infrastructure.Interfaces;
using ClimateChangeEducation.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.IO.Pipelines;
using System.Text.RegularExpressions;

namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultimediaUploadController : ControllerBase
    {

        private readonly ILocalImageStorageRepository _localStorageRepo;
        private readonly ILogger<WeatherForecastController> _logger;


        public MultimediaUploadController(ILocalImageStorageRepository localStorageRepo, ILogger<WeatherForecastController> logger)
        {
            _localStorageRepo = localStorageRepo;
            _logger = logger;
        }

   

        [HttpPost]
        [Route("upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] string id, IFormFile profileImage)
        {
            try
            {
                var respResult = new FileUploadResponse
                {
                    FilePath = "",
                    ResponseMessage = ""
                };

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
                        respResult.FilePath = fileImagePath;
                        respResult.ResponseMessage = "Upload Successful";
                    }
                    return Ok(respResult.FilePath);
                }
                return NotFound();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }            
        }

        [HttpPost]
        [Route("upload-video")]
        public async Task<IActionResult> UploadVideo([FromRoute] string id, IFormFile videoFile)
        {
            try
            {
                var respResult = new FileUploadResponse
                {
                    FilePath = "",
                    ResponseMessage = ""
                };

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
                        respResult.FilePath = fileImagePath;
                        respResult.ResponseMessage = "Upload Successful";
                    }
                    return Ok(respResult.FilePath);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }            
        }

        [HttpPost]
        [Route("upload-document")]
        public async Task<IActionResult> UploadDocument([FromRoute] string id, IFormFile documentFile)
        {
            try
            {
                var respResult = new FileUploadResponse
                {
                    FilePath = "",
                    ResponseMessage = ""
                };

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
                        respResult.FilePath = fileImagePath;
                        respResult.ResponseMessage = "Upload Successful";
                    }
                    return Ok(respResult.FilePath);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getDocFile/{fileName}")]
        public IActionResult GetDocFile(string fileName)
        {
            try
            {
                var _resourceFolderPath = @"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Infrastructure\Resources\Documents\";

                var filePath = Path.Combine(_resourceFolderPath, fileName);

                if (!System.IO.File.Exists(filePath))
                    return NotFound();

                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var contentType = FileTypes.GetDocumentFileType(filePath);

                return File(fileStream, contentType, fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound();                  
            }            
        }

        [HttpGet("getImageFile/{fileName}")]
        public IActionResult GetImageFile(string fileName)
        {
            try
            {
                var _resourceFolderPath = @"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Infrastructure\Resources\Images\";

                var filePath = Path.Combine(_resourceFolderPath, fileName);

                if (!System.IO.File.Exists(filePath))
                    return NotFound();

                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var contentType = FileTypes.GetDocumentFileType(filePath);

                return File(fileStream, contentType, fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound();
            }            
        }

        [HttpGet("getVideoFile/{fileName}")]
        public IActionResult GetVideoFile(string fileName)
        {
            try
            {
                var _resourceFolderPath = @"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Infrastructure\Resources\Videos\";

                var filePath = Path.Combine(_resourceFolderPath, fileName);

                if (!System.IO.File.Exists(filePath))
                    return NotFound();

                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var contentType = FileTypes.GetDocumentFileType(filePath);

                return File(fileStream, contentType, fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound();
            }            
        }      
    }
}
