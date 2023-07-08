using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Interfaces
{
    public interface ILocalImageStorageRepository
    {
        Task<string> UploadImg(IFormFile file, string fileName);                   
        Task<string> UploadVideo(IFormFile file, string fileName);                   
        Task<string> UploadDocument(IFormFile file, string fileName);                   
    }
}
