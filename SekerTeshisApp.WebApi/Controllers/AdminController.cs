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
        public IActionResult GetUserStatics()
        {

            return Ok();
        }

        [HttpGet("getUser/{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            return Ok();
        }
    }
}
