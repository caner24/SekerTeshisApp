using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.RateLimiting;
using SekerTeshisApp.Application.ActionFilters;
using SekerTeshisApp.Application.CQRS.Home.Requests;
using SekerTeshisApp.Application.CQRS.Home.Responses;
using SekerTeshisApp.Application.Mail.Abstract;
using SekerTeshisApp.WebApi.MessageQueue.RabbitMQ;
using System.Text.Json;

namespace SekerTeshisApp.WebApi.Controllers
{
    [ApiController]
    //[Authorize]
    [ApiVersion("1.0")]
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
        public async Task<IActionResult> FoodList([FromQuery] GetUserFoodListRequest userFoodListRequest)
        {
            var response = await _mediator.Send(userFoodListRequest);
            return Ok(response.FoodLists);
        }

        [HttpGet("exercisesList")]
        public async Task<IActionResult> ExercisesListAsync([FromQuery] GetUserExercisesRequest userExerciseListRequest)
        {
            var response = await _mediator.Send(userExerciseListRequest);
            return Ok(response.Exercises);
        }

        [HttpGet("getLast7Diabetes")]
        public async Task<IActionResult> Last7Diabetes([FromQuery] Last7DiabetesRequest last7DiabetesRequest)
        {
            var response = await _mediator.Send(last7DiabetesRequest);
            return Ok(response);
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
        [ValidationFilter]
        public async Task<IActionResult> CalculateSugar([FromBody] CalculateSugarRequest calculateSugarRequest)
        {
            var response = await _mediator.Send(calculateSugarRequest);
            Publisher.CreateFoodListQuaqe(new Models.FoodListModel { Mail = response.MailAdress, Morning = response.Morning, Afternoon = response.Afternoon, Evening = response.Evening });
            Publisher.CreateExercisesListQuaqe(new Models.ExercisesListModel { Mail = response.MailAdress, Afternoon = response.AfternoonExercises, Evening = response.EveningExercises });
            return Ok(response);
        }
    }
}
