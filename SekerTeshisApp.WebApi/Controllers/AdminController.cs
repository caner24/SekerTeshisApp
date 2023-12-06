using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SekerTeshisApp.Application.CQRS.Admin.Requests;

namespace SekerTeshisApp.WebApi.Controllers
{
    [ApiController]
    //[Authorize(Roles = "Admin")]
    [Route("api/admin")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("userStatics")]
        public async Task<IActionResult> GetUserStatics([FromQuery] GetUsersRequest getUserRequests)
        {
            if (!getUserRequests.ValidateYearRange)
            {
                return BadRequest("Bu değer aralığında ölçüm bulunamamakta !.");
            }

            var response = await _mediator.Send(getUserRequests);
            var metadata = new
            {
                response.TotalCount,
                response.PageSize,
                response.CurrentPage,
                response.TotalPages,
                response.HasNext,
                response.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }


        [HttpGet("getUser/{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            return Ok();
        }
    }
}
