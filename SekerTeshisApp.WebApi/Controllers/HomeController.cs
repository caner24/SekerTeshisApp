﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SekerTeshisApp.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/home")]
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
            return View(foodList);
        }

        [HttpGet("exercisesList")]
        public IActionResult ExercisesList()
        {
            return View();
        }

        [HttpGet("index")]
        public IActionResult CalculateSugar()
        {
            return View();
        }
    }
}
