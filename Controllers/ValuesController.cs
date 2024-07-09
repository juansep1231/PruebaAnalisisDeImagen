using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Azure;

namespace BlazorFileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            BinaryData imageData;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0; // Reset the stream position to the beginning
                imageData = BinaryData.FromStream(memoryStream);
            }

            // Do something with the imageData (e.g., save to a database, process it, etc.)
            // For demonstration, let's return the size of the binary data
            return Ok(new { Size = imageData.ToArray().Length });
        }
    }
}
