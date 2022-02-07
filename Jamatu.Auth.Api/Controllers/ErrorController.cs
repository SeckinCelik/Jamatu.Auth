using Jamatu.Auth.Core.Exception;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Jamatu.Auth.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }
        [Route("error-local-development")]
        public IActionResult ErrorLocalDevelopment()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            using (_logger.BeginScope(new Dictionary<string, object>
            {
                ["Message"] = context.Error.Message,
                ["StackStrace"] = context.Error.StackTrace,
                ["ExceptionType"] = context.Error switch
                {
                    Core.Exception.ValidationException _ => "ValidationException",
                    ApplicationException _ => "BusinessException",
                    _ => "Unhandled"
                }
            }))
            {
                _logger.Log(LogLevel.Error, "Auth Api Error Logger - {Message}", context.Error.Message);
            }

            switch (context.Error)
            {
                case Core.Exception.ValidationException businessValidationException:
                    {
                        var detail = businessValidationException.ProblemDetails;
                        return ValidationProblem(detail);
                    }
                case ApplicationException businessException:
                    return Problem(
                        type: businessException.ProblemDetails.Type,
                        instance: businessException.ProblemDetails.Instance,
                        detail: businessException.ProblemDetails.Detail,
                        title: businessException.ProblemDetails.Title,
                        statusCode: 400
                    );
                default:
                    return Problem(
                        context.Error.StackTrace, "unhandled", 500, context.Error.Message, "auth000");
            }
        }

        [Route("error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            using (_logger.BeginScope(new Dictionary<string, object>
            {
                ["Message"] = context.Error.Message,
                ["StackStrace"] = context.Error.StackTrace,
                ["ExceptionType"] = context.Error switch
                {
                    Core.Exception.ValidationException _ => "ValidationException",
                    ApplicationException _ => "BusinessException",
                    _ => "Unhandled"
                }
            }))
            {
                _logger.Log(LogLevel.Error, "Auth Api Error Logger - {Message}", context.Error.Message);
            }

            switch (context.Error)
            {
                case Core.Exception.ValidationException businessValidationException:
                    {
                        var detail = businessValidationException.ProblemDetails;
                        return ValidationProblem(detail);
                    }
                case ApplicationException businessException:
                    return Problem(
                        type: businessException.ProblemDetails.Type,
                        instance: businessException.ProblemDetails.Instance,
                        detail: businessException.ProblemDetails.Detail,
                        title: businessException.ProblemDetails.Title,
                        statusCode: 400
                    );
                default:
                    return Problem(context.Error.Message, "unhandled", 500, "Unhandled Exception", "auth000");
            }
        }
    }
}
