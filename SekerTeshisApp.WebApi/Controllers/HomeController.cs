using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SekerTeshisApp.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/home")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class HomeController : Controller
    {
        [HttpGet("foodList")]
        public IActionResult FoodList()
        {
            var foodList = new
            {
                FoodName = "Tarhana Corbasi",
                FoodCode = 123
            };
            return Ok(foodList);
        }

        [HttpGet("exercisesList")]
        public IActionResult ExercisesList()
        {
            return Ok();
        }

        [HttpGet("index")]
        public IActionResult CalculateSugar()
        {
            return Ok();
        }
    }
}
