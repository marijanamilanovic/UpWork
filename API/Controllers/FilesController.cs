using Application.DTO.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private static IEnumerable<string> allowedExtensions = new List<string>
        {
            ".jpg", ".jpeg", ".png", ".mp4"
        };

        // POST api/<FilesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromForm] UploadFileDTO data)
        {
            var extension = Path.GetExtension(data.File.FileName);

            if (!allowedExtensions.Contains(extension))
            {
                return new UnsupportedMediaTypeResult();
            }

            var fileName = Guid.NewGuid().ToString() + extension;

            var savePath = Path.Combine("wwwroot", "temp", fileName);

            using var fs = new FileStream(savePath, FileMode.Create);

            data.File.CopyTo(fs);

            return StatusCode(201, new { File = fileName });
        }
    }
}
