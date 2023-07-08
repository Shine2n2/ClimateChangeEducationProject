using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Repositories
{
    public class LocalImageStorageRepository: ILocalImageStorageRepository
    {
        public async Task<string> UploadImg(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Infrastructure\Resources\Images\", fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return GetRelativePathforImage(fileName);
        }

        private string GetRelativePathforImage(string fileName)
        {
            return Path.Combine(@"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Infrastructure\Resources\Images\", fileName);
        }

        public async Task<string> UploadVideo(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Infrastructure\Resources\Videos\", fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return GetRelativePathForVideo(fileName);
        }

        private string GetRelativePathForVideo(string fileName)
        {
            return Path.Combine(@"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Infrastructure\Resources\Videos\", fileName);
        }

        public async Task<string> UploadDocument(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Infrastructure\Resources\Documents\", fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return GetRelativePathForDocument(fileName);
        }

        private string GetRelativePathForDocument(string fileName)
        {
            return Path.Combine(@"C:\Users\Decagon\Desktop\ezimoha\PROJECT\Backend\ClimateChangeEducationProject\ClimateChangeEducation.API\ClimateChangeEducation.Infrastructure\Resources\Documents\", fileName);
        }


    }
}
