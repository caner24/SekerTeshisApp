using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SekerTeshisApp.WebApi.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/admin")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AdminController : Controller
    {

        [HttpGet("userStatics")]
        public IActionResult GetStatics()
        {
            return Ok();
        }
        [HttpGet("getUser/{id}")]
        public IActionResult GetStatics([FromBody] int id)
        {
            return Ok();
        }


    }
}
