using ImportCsv.Api.Contracts;
using ImportCsv.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ImportCsv.Api.Middlewares
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (InvalidRequestExpection ex)
            {
                _logger.LogError(ex, $"Invalid Request Expection for endpoit: {context.Request.Path}");
                await HandleExceptionAsync(context, ex);
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, $"Business Exception: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unexpected error: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var json = new BaseMessageException
            {
                StatusCode = context.Response.StatusCode,
                Message = "There was a small problem, but our team is already working to solve it.",
                Detailed = exception.StackTrace
            };

            switch (exception)
            {
                case InvalidRequestExpection mapper:
                    json.StatusCode = context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    json.Message = exception.Message;
                    json.Errors = mapper.Errors;
                    break;
                case BusinessException business :
                    json.StatusCode = context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    json.Message = business.Message;
                    break;
            }

            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }
    }
}