using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using SeherTeshisApp.Application.Account.Requests;
using SekerTeshis.Core.CrossCuttingConcerns.MailService;
using SekerTeshis.Entity;
using SekerTeshis.Entity.DTO;
using SekerTeshis.Entity.Exceptions;
using SekerTeshisApp.Application.Account.Requests;
using SekerTeshisApp.Application.ActionFilters;
using SekerTeshisApp.Application.Mail.Abstract;
using SekerTeshisApp.WebApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SekerTeshisApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;
        private readonly IMailSender _mailSender;
        public AccountController(UserManager<User> user, IMediator mediator, IMailSender mailSender)
        {
            _userManager = user;
            _mediator = mediator;
            _mailSender = mailSender;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest loginUserRequest)
        {
            var identityResult = await _mediator.Send(loginUserRequest);
            if (!identityResult.IsLoggedIn)
                throw new EmailPasswordException();

            var response = new
            {
                AccesToken = identityResult.AccessToken,
                RefreshToken = identityResult.RefreshToken
            };
            return Ok(response);
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
            var callback = Url.Action(nameof(ResetPassword), "Account", new { identityResult.Token, email = user.Email }, Request.Scheme);
            var message = new Message(new string[] { user.Email }, "Mail Onaylama", MailBody.DefaultMailBody(user.Email.Substring(0, user.Email.IndexOf("@")), "Lütfen Mailinizi Onaylayiniz ", "2 hour", callback.ToString()), null);
            await _mailSender.SendEmailAsync(message);
            return StatusCode(201);
        }

        [HttpGet("resetPassword")]
        public IActionResult ResetPassword()
        {


            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmMailRequest confirmMailRequest)
        {
            ////var user = await _userManager.FindByEmailAsync(email);
            ////if (user == null)
            ////    return View("Error");
            //var result = await _userManager.ConfirmEmailAsync(user, token);

            return Ok();
        }
    }
}
