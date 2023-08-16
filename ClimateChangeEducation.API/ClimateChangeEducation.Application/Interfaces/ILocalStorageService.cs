using ClimateChangeEducation.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Application.Interfaces
{
    public interface ILocalStorageService
    {
        Task<FileUploadResponse> UploadVideoService(string id, IFormFile videoFile);
        Task<FileUploadResponse> UploadImageService(string id, IFormFile profileImage);
        Task<FileUploadResponse> UploadDocumentService(string id, IFormFile documentFile);
    }
}
