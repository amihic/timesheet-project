using API.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCode(exception);

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            };

            var json = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(json);
        }

        private int GetStatusCode(Exception exception)
        {
            switch (exception)
            {
                case UnauthorizedAccessException _:
                    return (int)HttpStatusCode.Unauthorized;
                case NotFoundException _:
                    return (int)HttpStatusCode.NotFound;
                case BadRequestException _:
                    return (int)HttpStatusCode.BadRequest;
                case NullReferenceException _://pitaj
                    return (int)HttpStatusCode.BadRequest;
                default:
                    return (int)HttpStatusCode.InternalServerError;
            }
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }

    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
    public class HttpResponseException : Exception
    {
        public int StatusCode { get; set; }

        public HttpResponseException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
