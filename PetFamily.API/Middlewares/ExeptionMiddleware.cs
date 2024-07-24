using PetFamily.Domain.Common;
using System.Net;

namespace PetFamily.API.Middlewares;

public class ExeptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExeptionMiddleware> _logger;

    public ExeptionMiddleware(RequestDelegate next, ILogger<ExeptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
        
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            var error = new Error("server.internal", e.Message);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(error);
        }
            
    }
}