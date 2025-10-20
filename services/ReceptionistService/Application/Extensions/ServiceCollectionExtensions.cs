using ReceptionistService.Application.Interfaces;
using ReceptionistService.Infrastructure.Data;
using ReceptionistService.Infrastructure.Repositories;


namespace ReceptionistService.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static IServiceCollection AddDapperContext(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton(new DapperContext(connectionString));

        return services;
    }

    public static IServiceCollection AddDIServices(this IServiceCollection services)
    {
        services.AddScoped<ReceptionistRepository>();
        services.AddScoped<IReceptionistService, ReceptionistService.Application.Services.ReceptionistService>();

        return services;
    }
}
