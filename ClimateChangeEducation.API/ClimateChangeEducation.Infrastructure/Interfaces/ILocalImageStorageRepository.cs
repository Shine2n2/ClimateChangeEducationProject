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
        Task<string> Upload(IFormFile file, string fileName);                   
    }
}
