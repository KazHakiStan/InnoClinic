using ResultsService.Infrastructure.Middleware;

namespace ResultsService.Infrastructure.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseApiPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseMiddleware<AuthValidationMiddleware>();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}
