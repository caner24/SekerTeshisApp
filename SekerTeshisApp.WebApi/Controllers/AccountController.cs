using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SeherTeshisApp.Application.Account.Requests;
using SekerTeshis.Entity;
using SekerTeshis.Entity.DTO;
using SekerTeshisApp.Application.ActionFilters;

namespace SekerTeshisApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;
        public AccountController(UserManager<User> user, IMediator mediator)
        {
            _userManager = user;
            _mediator = mediator;
        }
        [HttpGet("login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest user)
        {
            var identityResult = await _mediator.Send(user);
            if (!identityResult.IsCreated.Succeeded)
            {
                foreach (var item in identityResult.IsCreated.Errors)
                {
                    ModelState.TryAddModelError(item.Code, item.Description);
                }
                return BadRequest(identityResult);
            }
            return StatusCode(201);
        }

        [HttpGet("resetPassword")]
        public IActionResult ResetPassword()
        {
            return Ok();
        }
    }
}
