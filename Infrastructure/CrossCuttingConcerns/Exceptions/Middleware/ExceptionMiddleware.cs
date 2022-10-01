using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.CrossCuttingConcerns.Exceptions.Middleware
{
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
                await HandleExceptionAsync(context, exception);
            }
        }

        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            if (exception.GetType() == typeof(ValidationException)) return CreateValidationException(context, exception);
            return CreateInternalServerError(context, exception);
        }

        private Task CreateValidationException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
            object errors = ((ValidationException)exception).Errors;

            return context.Response.WriteAsync(new CustomValidationException
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Errors = errors
            }.ToString());
        }

        public Task CreateInternalServerError(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

            return context.Response.WriteAsync(new CustomExceptionDetail(StatusCodes.Status500InternalServerError, exception.Message).ToString());
        }

    }
}
