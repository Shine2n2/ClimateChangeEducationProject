using ClimateChangeEducation.Application.Interfaces;
using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Application.Services
{
    public class LocalStorageService:ILocalStorageService
    {
        private readonly ILocalImageStorageRepository _localStorageRepo;
        public LocalStorageService(ILocalImageStorageRepository localStorageRepo)
        {
            _localStorageRepo = localStorageRepo;
        }


        public async Task<FileUploadResponse> UploadImageService(string id, IFormFile profileImage)
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

                var respResult = new FileUploadResponse
                {
                    FilePath = "",
                    ResponseMessage = ""
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
                    return respResult;
                }
                respResult.FilePath = "";
                respResult.ResponseMessage = "No file attached";
                return respResult;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        
        public async Task<FileUploadResponse> UploadVideoService(string id, IFormFile videoFile)
        {
            try
            {
                var validExtensions = new List<string>
                {
                   ".mp4",
                   ".mkv",
                   ".avi"
                };

                var respResult = new FileUploadResponse
                {
                    FilePath = "",
                    ResponseMessage = ""
                };

                if (videoFile != null && videoFile.Length > 0)
                {                   
                    var extension = Path.GetExtension(videoFile.FileName);
                    if (validExtensions.Contains(extension))
                    {
                        var fileName = id + Path.GetExtension(videoFile.FileName);
                        var fileVideoPath = await _localStorageRepo.UploadVideo(videoFile, fileName);
                        respResult.FilePath = fileVideoPath;
                        respResult.ResponseMessage = "Upload Successful";
                    }                                     
                    return respResult;
                }
                respResult.FilePath = "";
                respResult.ResponseMessage = "No file attached";
                return respResult;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        public async Task<FileUploadResponse> UploadDocumentService(string id, IFormFile documentFile)
        {
            try
            {
                var validExtensions = new List<string>
                {
                   ".pdf"
                };

                var respResult = new FileUploadResponse
                {
                    FilePath = "",
                    ResponseMessage = ""
                };

                if (documentFile != null && documentFile.Length > 0)
                {
                    var extension = Path.GetExtension(documentFile.FileName);
                    if (validExtensions.Contains(extension))
                    {
                        var fileName = id + Path.GetExtension(documentFile.FileName);
                        var fileDocPath = await _localStorageRepo.UploadDocument(documentFile, fileName);
                        respResult.FilePath = fileDocPath;
                        respResult.ResponseMessage = "Upload Successful";
                    }                                        
                    return respResult;
                }
                respResult.FilePath = "";
                respResult.ResponseMessage = "No file attached";
                return respResult;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured", ex);
            }

        }
    }
}
