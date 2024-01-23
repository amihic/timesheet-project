using API.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using OpenQA.Selenium;
using System;
using System.Net;
using System.Threading.Tasks;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            CustomErrorResponse customResponse = new CustomErrorResponse();

            switch (exception)
            {
                case UnauthorizedAccessException _:
                    customResponse.StatusCode = (int)HttpStatusCode.Unauthorized;
                    customResponse.Message = "Unauthorized access.";
                    break;
                
                case NotFoundException _:
                    customResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    customResponse.Message = "Resource not found.";
                    break;
                case DirectoryNotFoundException _:
                    customResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    customResponse.Message = "Resource not found.";
                    break;
                case FormatException _:
                case NullReferenceException _:
                    customResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    customResponse.Message = "Bad request format.";
                    break;
                case Exception _:
                    customResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    customResponse.Message = "Wrong password";
                    break;
                default:
                    customResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    customResponse.Message = "Internal server error.";
                    break;
            }

            context.Response.StatusCode = customResponse.StatusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(customResponse));
        }
    }
}

public static class CustomExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}
