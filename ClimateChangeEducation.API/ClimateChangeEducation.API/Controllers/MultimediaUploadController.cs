using ClimateChangeEducation.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultimediaUploadController : ControllerBase
    {
        //[HttpPost]
        //[Route("[controller]/{studentId:guid}/upload-image")]
        //public async Task<IActionResult> UploadImage([FromRoute] Guid studentId, IFormFile profileImage)
        //{
        //    var validExtensions = new List<string>
        //    {
        //       ".jpeg",
        //       ".png",
        //       ".gif",
        //       ".jpg"
        //    };

        //    if (profileImage != null && profileImage.Length > 0)
        //    {
        //        var extension = Path.GetExtension(profileImage.FileName);
        //        if (validExtensions.Contains(extension))
        //        {
        //            if (await studentRepository.Exists(studentId))
        //            {
        //                var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);

        //                var fileImagePath = await imageRepository.Upload(profileImage, fileName);

        //                if (await studentRepository.UpdateProfileImage(studentId, fileImagePath))
        //                {
        //                    return Ok(fileImagePath);
        //                }

        //                return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image");
        //            }
        //        }

        //        return BadRequest("This is not a valid Image format");
        //    }

        //    return NotFound();
        //}
    }
}
