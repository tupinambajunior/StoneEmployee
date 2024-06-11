using Microsoft.AspNetCore.Mvc;
using StoneEmployee.Application.DTO;
using System.ComponentModel.DataAnnotations;

namespace StoneEmployee.API.Extensions
{
    public class ControllerCustom : ControllerBase
    {
        [NonAction]
        public ActionResult HandleException(Exception ex, ILogger _logger)
        {
            var result = new APIResultDTO
            {
                Success = false,
                Data = null,
                Message = ex.Message
            };

            if (ex is ValidationException || ex is FluentValidation.ValidationException)
            {
                _logger.LogInformation("Validation exception {message}", ex);
                result.Type = "warning";
                return BadRequest(result);
            }
            else
            {
                _logger.LogInformation("Exception {message}", ex);
                result.Type = "error";
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        [NonAction]
        public ActionResult OkResponse(object dados, string mensagem = "")
        {
            var result = new APIResultDTO
            {
                Success = true,
                Data = dados,
                Message = mensagem,
                Type = "success"
            };

            return Ok(result);
        }
    }
}
