﻿using AutoMapper;
using ClimateChangeEducation.Infrastructure.Interfaces;
using ClimateChangeEducation.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultimediaUploadController : ControllerBase
    {

        private readonly ILocalImageStorageRepository _localStorageRepo;        
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MultimediaUploadController(ILocalImageStorageRepository localStorageRepo, IWebHostEnvironment webHostEnvironment)
        {
            _localStorageRepo = localStorageRepo;
            _webHostEnvironment = webHostEnvironment;
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


        [HttpPost]
        [Route("upload-fil")]
        public IActionResult UploadFil(IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    string uploadsFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { filePath });
                }

                return BadRequest("No file uploaded.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("GetFil")]
        public IActionResult GetFiles()
        {
            string uploadsFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "Resources");
            var files = Directory.GetFiles(uploadsFolderPath)
                                .Select(Path.GetFileName)
                                .ToList();
            return Ok(files);
        }

        [HttpGet("{id}/sdf")]
        public ActionResult GetPicture(Guid id)
        {
            var files = Directory.GetFiles(@"Pictures\");
            foreach (var file in files)
            {
                if (file.Contains(id.ToString()))
                {
                    return File(System.IO.File.ReadAllBytes(file), "image/jpeg");
                }
            }
            return null;
        }

        [HttpGet]
        public IActionResult GetFilessss()
        {
            string uploadsFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource");
            var imageExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif" };

            var imageFiles = Directory.GetFiles(uploadsFolderPath)
                                     .Where(file => imageExtensions.Contains(Path.GetExtension(file).ToLower()))
                                     .Select(Path.GetFileName)
                                     .ToList();

            return Ok(imageFiles);
        }
    }
}
