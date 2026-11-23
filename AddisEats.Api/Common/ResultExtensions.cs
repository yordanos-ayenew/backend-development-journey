using Microsoft.AspNetCore.Mvc;

namespace AddisEats.Api.Common;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(
        this Result<T> result,
        ControllerBase controller)
    {
        if (!result.IsSuccess)
        {
            var error = result.Error!;

            var problem = new ProblemDetails
            {
                Title = error.Message,
                Status = error.Status
            };

            problem.Extensions["code"] = error.Code;
            problem.Extensions["traceId"] =
                controller.HttpContext.TraceIdentifier;

            return new ObjectResult(problem)
            {
                StatusCode = error.Status
            };
        }

        return controller.Ok(result.Value);
    }
}