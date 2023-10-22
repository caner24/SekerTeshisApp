using Microsoft.AspNetCore.Mvc;

namespace SekerTeshisApp.WebApi.Controllers
{
    [ApiController]
    [Route("user")]
    public class AccountController : Controller
    {
        [HttpGet("login")]
        public IActionResult Login()
        {
            return Ok();
        }
        [HttpGet("register")]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpGet("resetPassword")]
        public IActionResult ResetPassword()
        {
            return Ok();
        }
    }
}
