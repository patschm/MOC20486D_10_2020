using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace RestService.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
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
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.BadRequest;

            return WriteExceptionAsync(context, exception, code);
        }
        private static Task WriteExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;
            if (exception.InnerException != null)
            {
                return response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    error = new
                    {
                        message = exception.Message,
                        exception = exception.GetType().Name,
                        stack = exception.StackTrace,
                        innerException = new
                        {
                            message = exception.InnerException.Message,
                            exception = exception.InnerException.GetType().Name,
                            stack = exception.InnerException.StackTrace
                        }
                    }
                }));
            }
            return response.WriteAsync(JsonConvert.SerializeObject(new
            {
                error = new
                {
                    message = exception.Message,
                    exception = exception.GetType().Name,
                    stack = exception.StackTrace
                }
            }));
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorMiddleware>();
        }
    }
}
