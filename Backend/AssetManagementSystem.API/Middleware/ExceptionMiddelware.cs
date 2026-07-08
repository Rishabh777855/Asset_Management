using System.Net;
using System.Text.Json;
using AssetManagementSystem.Application.DTOs.Common;
using AssetManagementSystem.Application.Exceptions;

namespace AssetManagementSystem.API.Middleware;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch(Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";

        var statusCode = exception switch
        {
           NotFoundException => HttpStatusCode.NotFound,
            BadRequestException => HttpStatusCode.BadRequest,
            UnauthorizedException => HttpStatusCode.Unauthorized,
            _ => HttpStatusCode.InternalServerError 
        };

        httpContext.Response.StatusCode = (int)statusCode;

        var response = new ErrorResponseDto
        {
            StatusCode = httpContext.Response.StatusCode,
            Message = exception.Message
        };

        var json = JsonSerializer.Serialize(response);
        
        await httpContext.Response.WriteAsync(json);
    }
}