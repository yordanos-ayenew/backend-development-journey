using Microsoft.AspNetCore.Mvc.Filters;

namespace AddisEats.Api.Filters;

public class AuditActionFilter : IActionFilter
{
    private readonly ILogger<AuditActionFilter> _logger;

    public AuditActionFilter(ILogger<AuditActionFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation(
            "Executing action {Action}. Arguments: {@Arguments}",
            context.ActionDescriptor.DisplayName,
            context.ActionArguments);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var statusCode = (context.Result as Microsoft.AspNetCore.Mvc.ObjectResult) ?.StatusCode;

        _logger.LogInformation(
            "Action {Action} completed with status {StatusCode}",
            context.ActionDescriptor.DisplayName,
            statusCode);
    }
}