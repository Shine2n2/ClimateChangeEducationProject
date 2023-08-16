using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Helpers
{
    public static class FileTypes
    {                
        private static readonly Dictionary<string, string> _mappingsDocument = new Dictionary<string, string>
        {           
            { ".pdf", "application/pdf" },                    
        };

        private static readonly Dictionary<string, string> _mappingsImage = new Dictionary<string, string>
        {
            { ".jpg", "image/jpeg" },
            { ".jpeg", "image/jpeg" },
            { ".png", "image/png" },           
            { ".bmp", "image/bmp" }                      
        };

        private static readonly Dictionary<string, string> _mappingsVideo = new Dictionary<string, string>
        {            
            { ".mp4", "video/mp4" },
            { ".avi", "video/x-msvideo" },
            { ".mkv", "video/mkv" },
        };

        public static string GetVideoFileType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return _mappingsVideo.TryGetValue(extension, out var mime) ? mime : "application/octet-stream";
        }

        public static string GetImageFileType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return _mappingsImage.TryGetValue(extension, out var mime) ? mime : "application/octet-stream";
        }

        public static string GetDocumentFileType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return _mappingsDocument.TryGetValue(extension, out var mime) ? mime : "application/octet-stream";
        }
    }
}
