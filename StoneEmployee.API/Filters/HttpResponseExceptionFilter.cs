using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using StoneEmployee.Core.Exceptions;
using StoneEmployee.Application.DTO;

namespace StoneEmployee.API.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is NotFoundException notFoundException)
            {
                context.Result = new NotFoundObjectResult(new APIResultDTO
                {
                    Success = false,
                    Data = null,
                    Message = notFoundException.Message,
                    Type = "error"
                });
                context.ExceptionHandled = true;
            }
            else if (context.Exception is ValidationException validationException)
            {
                context.Result = new NotFoundObjectResult(new APIResultDTO
                {
                    Success = false,
                    Data = null,
                    Message = validationException.Message,
                    Type = "warning"
                });
                context.ExceptionHandled = true;
            }
            else if (context.Exception is FluentValidation.ValidationException fluentValidationException)
            {
                context.Result = new NotFoundObjectResult(new APIResultDTO
                {
                    Success = false,
                    Data = null,
                    Message = fluentValidationException.Message,
                    Type = "warning"
                });
                context.ExceptionHandled = true;
            }
            else if (context.Exception is Exception exception)
            {
                context.Result = new ObjectResult(new APIResultDTO
                {
                    Success = false,
                    Data = null,
                    Message = exception.Message,
                    Type = "error"
                })
                { StatusCode = StatusCodes.Status500InternalServerError };
                context.ExceptionHandled = true;
            }
        }
    }
}
