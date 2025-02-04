﻿using Application.Exceptions;
using Application;
using Implementation.DTO;
using FluentValidation;

namespace API.Core
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private IExceptionLogger _logger;
        private IApplicationActor _actor;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, IExceptionLogger logger, IApplicationActor actor)
        {
            _next = next;
            _logger = logger;
            _actor = actor;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                if (exception is UnauthorizedAccessException)
                {
                    httpContext.Response.StatusCode = 401;
                    return;
                }

                if (exception is ValidationException ex)
                {
                    await HandleValidationExceptionAsync(httpContext, ex);
                    return;
                }
                if (exception is EntityNotFoundException)
                {
                    httpContext.Response.StatusCode = 404;
                    return;
                }
                if (exception is ConflictException)
                {
                    httpContext.Response.StatusCode = 409;
                    var body = new { Error = exception.Message };

                    await httpContext.Response.WriteAsJsonAsync(body);
                    return;
                }

                Guid errorId = _logger.Log(exception, _actor);

                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsJsonAsync(new { Message = $"An unexpected error has occured. Please contact our support with this ID - {errorId}." });
            }
        }

        private Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 422;

            var errors = exception.Errors.Select(e => new ValidationError
            {
                Property = e.PropertyName,
                Error = e.ErrorMessage
            });

            return context.Response.WriteAsJsonAsync(errors);
        }
    }
}
