namespace AddisEats.Api.Middleware;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public ApiKeyMiddleware(
        RequestDelegate next,
        IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var expectedKey = _configuration["ApiKey"];
        var providedKey = context.Request.Headers["X-API-Key"].FirstOrDefault();

        if (string.IsNullOrWhiteSpace(expectedKey) ||
            providedKey != expectedKey)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new
            {
                code = "INVALID_API_KEY",
                message = "A valid API key is required."
            });

            return;
        }

        await _next(context);
    }
}