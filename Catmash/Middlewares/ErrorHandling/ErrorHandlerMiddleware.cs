using Catmash.Domain;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catmash.Middlewares.ErrorHandling
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception e)
        {   
            var result = JsonSerializer.Serialize(new { message = e.Message });

            context.Response.ContentType = MediaTypeNames.Application.Json;

            switch (e)
            {
                case ValidationException _:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            return context.Response.WriteAsync(result);
        }
    }
}
