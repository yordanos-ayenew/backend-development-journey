namespace AddisEats.Api.Middleware;

public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CorrelationIdMiddleware> _logger;

    public CorrelationIdMiddleware(
        RequestDelegate next,
        ILogger<CorrelationIdMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var id = context.Request.Headers["X-Correlation-Id"]
            .FirstOrDefault() ?? Guid.NewGuid().ToString("N");

        context.TraceIdentifier = id;
        context.Response.Headers["X-Correlation-Id"] = id;

        using (_logger.BeginScope(
            new Dictionary<string, object>
            {
                ["CorrelationId"] = id
            }))
        {
            await _next(context);
        }
    }
}