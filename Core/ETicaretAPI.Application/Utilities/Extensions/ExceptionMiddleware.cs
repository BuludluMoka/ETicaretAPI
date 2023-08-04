using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using OnionArchitecture.Application.Utilities.Exceptions;
using Core.Application.Utilities.Results;
using OnionArchitecture.Application.Enums;
using OnionArchitecture.Application.Abstractions.Services.Global;

namespace Core.Utilities.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggingService _loggingService;

        public ExceptionMiddleware(RequestDelegate next, ILoggingService loggingService)
        {
            _next = next;
            _loggingService = loggingService;
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
            httpContext.Response.StatusCode = (int)(e is BadRequestExceptionBase ? HttpStatusCode.BadRequest : HttpStatusCode.InternalServerError);
            return httpContext.Response.WriteAsync(
                JsonSerializer.Serialize(GenerateLogResult(e)));
        }

        private IResultData GenerateLogResult(Exception e) => new ResultDataGenerator().Generate(new Result
        {
            Data = _loggingService.Log($"{e.Message}\n\n{e.StackTrace}", e is BadRequestExceptionBase ? LogType.BadRequest
                        : LogType.Exception),
            ResultInfo = e is BadRequestExceptionBase ex ? ex.ExceptionResult : ResultInfo.InternalServerError
        });
    }
}