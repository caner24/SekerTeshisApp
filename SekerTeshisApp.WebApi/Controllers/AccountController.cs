using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.RateLimiting;
using Newtonsoft.Json.Linq;
using SekerTeshis.Core.CrossCuttingConcerns.MailService;
using SekerTeshis.Entity;
using SekerTeshis.Entity.DTO;
using SekerTeshis.Entity.Exceptions;
using SekerTeshisApp.Application.ActionFilters;
using SekerTeshisApp.Application.CQRS.Account.Requests;
using SekerTeshisApp.Application.Mail.Abstract;
using SekerTeshisApp.WebApi.MessageQueue.RabbitMQ;
using SekerTeshisApp.WebApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SekerTeshisApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/account")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AccountController : Controller
    {

        private readonly MyMessageConsumer _messageConsumer;
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;
        private readonly IMailSender _mailSender;
        public AccountController(UserManager<User> user, IMediator mediator, IMailSender mailSender, MyMessageConsumer messageConsumer)
        {
            _userManager = user;
            _mediator = mediator;
            _mailSender = mailSender;
            _messageConsumer = messageConsumer;
        }

        [HttpGet("consuming")]
        public IActionResult StartConsuming()
        {
            _messageConsumer.StartConsuming();
            return Ok("Consumer başlatıldı.");
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
                RefreshToken = identityResult.RefreshToken,
                UserId = identityResult.UserId,
                Message = "Giris",
                IsAdmin = identityResult.IsAdmin
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
            var callback = Url.Action(nameof(ConfirmEmail), "Account", new ConfirmMailRequest { Token = identityResult.Token, Mail = user.Email }, Request.Scheme);
            ConfirmMailModel confirmMailModel = new ConfirmMailModel { Email = user.Email, Callback = callback };
            Publisher.CreateMailConfirmQuaqe(confirmMailModel, false);

            return Ok(identityResult);
        }

        [HttpPost("forgottonPassword")]
        public async Task<IActionResult> ForgottenPassword([FromBody] ForgottenPasswordRequest forgottenPasswordRequest)
        {
            var resetPassword = await _mediator.Send(forgottenPasswordRequest);
            Publisher.CraeteForgetEmailQuaqe(resetPassword, false);
            resetPassword.Message = "İlgili mail adresinize şifre sifirlama linki gönderildi";
            return Ok(resetPassword);
        }

        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest resetPasswordRequest)
        {
            var resetPassword = await _mediator.Send(resetPasswordRequest);

            if (!resetPassword.Result.Succeeded)
            {
                foreach (var item in resetPassword.Result.Errors)
                {
                    ModelState.TryAddModelError(item.Code, item.Description);
                }
                return BadRequest(resetPassword);
            }
            resetPassword.Message = "Şifreniz başarili bir şekilde değiştirildi.";
            return Ok(resetPassword);
        }

        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmMailRequest confirmMailRequest)
        {
            var emailConfirm = await _mediator.Send(confirmMailRequest);

            if (!emailConfirm.Result.Succeeded)
            {
                foreach (var error in emailConfirm.Result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Content("Email adresiniz başarılı bir şekilde onaylanmıştır");
        }
    }
}
