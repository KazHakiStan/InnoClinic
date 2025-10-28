using DocumentsService.Infrastructure.Services;

namespace DocumentsService.Infrastructure.Middleware;

public class AuthValidationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, AuthClientService authClient)
    {
        var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
        if (authHeader is null || !authHeader.StartsWith("Bearer "))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        var token = authHeader["Bearer ".Length..];
        var valid = await authClient.ValidateTokenAsync(token);

        if (!valid)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        await _next(context);
    }
}
