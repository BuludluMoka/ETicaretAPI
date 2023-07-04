using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using Core.Utilities.Exceptions;
using Core.Utilities.Logging;
using Core.Utilities.Results;

namespace Core.Utilities.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 
                (int)(e is BadRequestExceptionBase 
                    ? HttpStatusCode.BadRequest 
                    : HttpStatusCode.InternalServerError);
            

            return httpContext.Response.WriteAsync(
                JsonSerializer.Serialize(GenerateLogResult(e)));
        }

        private IResultData GenerateLogResult(
            Exception e)
            => ResultDataGenerator.Generate(new Result
            {
                Data = _logger.Log(
                    $"{e.Message}\n\n{e.StackTrace}",
                    e is BadRequestExceptionBase 
                        ? LogType.BadRequest 
                        : LogType.Exception),
                ResultInfo = e is BadRequestExceptionBase ex
                            ? ex.ExceptionResult
                            : ResultInfo.InternalServerError
            });
    }
}