using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.StaticFiles;

namespace SekerTeshisApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class FilesController : Controller
    {

        [HttpGet("getImageByName")]
        public async Task<IActionResult> GetImageByName([FromQuery] string imgName)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "\\Images\\FoodImages\\" + imgName);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(imagePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(imagePath);
            return File(bytes, contentType, Path.GetFileName(imagePath));
        }
    }
}
