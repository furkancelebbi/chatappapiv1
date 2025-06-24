using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.WebAPI.Middleware;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {

            _logger.LogError(
                "Beklenmedik bir hata oluştu.\n--- Hata Mesajı: {ErrorMessage}\n--- StackTrace ---\n{StackTrace}",
                ex.Message,
                ex.StackTrace);


            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            ProblemDetails problemDetails = new()
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://tools.ietf.org/html/rfc9110#section-15.6.1",
                Title = "Sunucu Hatası",
                Detail = "İşlem sırasında beklenmedik bir hata oluştu. Lütfen daha sonra tekrar deneyin."
            };

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}