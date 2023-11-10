using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SekerTeshisApp.Application.CQRS.Home.Requests;
using SekerTeshisApp.Application.CQRS.Home.Responses;
using SekerTeshisApp.Application.Mail.Abstract;

namespace SekerTeshisApp.WebApi.Controllers
{
    [ApiController]

    [Route("api/home")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMailSender _mailSender;
        public HomeController(IMediator mediator, IMailSender mailSender)
        {
            _mediator = mediator;
            _mailSender = mailSender;
        }
        [HttpGet("foodList")]
        public IActionResult FoodList()
        {

            return Ok();
        }

        [HttpGet("exercisesList")]
        public IActionResult ExercisesList()
        {
            return Ok();
        }

        [HttpGet("getCalculateStatus")]
        public async Task<IActionResult> CalculateSugar([FromQuery] IsUserLockDownRequest isUserLockDownRequest)
        {
            var response = await _mediator.Send(isUserLockDownRequest);
            if (response.IsLockDown)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost("calculateSugar")]
        public async Task<IActionResult> CalculateSugar([FromBody] CalculateSugarRequest calculateSugarRequest)
        {
            var response = await _mediator.Send(calculateSugarRequest);
            return Ok(response);
        }
    }
}
