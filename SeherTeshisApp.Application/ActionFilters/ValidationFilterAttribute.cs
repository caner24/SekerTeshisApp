using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SekerTeshisApp.Application.ActionFilters
{
    public class ValidationFilterAttribute : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];

            var param = context.ActionArguments.SingleOrDefault(
                p => p.Value.ToString().Contains("Request")).Value;

            if (param == null)
            {
                context.Result = new BadRequestObjectResult($"Object is null controller {controller}, action {action}");
                return;
            }

            var validatorType = typeof(IValidator<>).MakeGenericType(param.GetType());
            var validator = context.HttpContext.RequestServices.GetService(validatorType) as IValidator;
            var validationContext = new ValidationContext<object>(param);


            if (validator != null)
            {
                var validationResult = validator.Validate(validationContext);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    context.Result = new UnprocessableEntityObjectResult(context.ModelState);
                    return;
                }
            }
            var result = await next();
        }
    }
}
