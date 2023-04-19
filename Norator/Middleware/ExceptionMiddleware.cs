using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Services;
using Core.Models;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Norator.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _loggerManager;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (UnauthorizedException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.Unauthorized,
                   $"{ex.Message}. Path:{context.Request.Path}.");
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.NotFound,
                    $"{ex.Message}. Path:{context.Request.Path}.");
            }
            catch (ForbidException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.Forbidden,
                   $"{ex.Message}. Path:{context.Request.Path}.");
            }
            catch (BadRequestException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest,
                   $"{ex.Message}. Path:{context.Request.Path}.");
            }
            catch (DivideByZeroException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                    $"{ex.Message}. Path:{context.Request.Path}.");
            }
            catch (HttpRequestException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                   $"{ex.Message}. Path:{context.Request.Path}.");
            }

            catch (DbUpdateConcurrencyException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                   $"{ex.Message}. Path:{context.Request.Path}.");
            }

            catch (DbUpdateException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                    $"{ex.Message}. Path:{context.Request.Path}.");
            }

            catch (RouteCreationException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                   $"{ex.Message}. Path:{context.Request.Path}.");
            }

            catch (KeyNotFoundException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                    $"{ex.Message}. Path:{context.Request.Path}.");
            }
            catch (WebException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                    $"{ex.Message}. Path:{context.Request.Path}.");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                   $"{ex.Message}. Path:{context.Request.Path}.");
            }
        }

        private Task HandleExceptionAsync(HttpContext context, HttpStatusCode errorCode, string errorMessage)
        {
            _loggerManager.LogWarn(errorMessage);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errorCode;
            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = errorMessage
            }.ToString());
        }
    }
}
