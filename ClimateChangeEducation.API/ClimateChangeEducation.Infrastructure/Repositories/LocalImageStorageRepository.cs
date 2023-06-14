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
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Images", fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return GetRelativePathforImage(fileName);
        }

        private string GetRelativePathforImage(string fileName)
        {
            return Path.Combine(@"Resources\Images", fileName);
        }

        public async Task<string> UploadVideo(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Videos", fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return GetRelativePathForVideo(fileName);
        }

        private string GetRelativePathForVideo(string fileName)
        {
            return Path.Combine(@"Resources\Videos", fileName);
        }
    }
}
