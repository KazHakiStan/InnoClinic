using ReceptionistService.BusinessLogic.Interfaces;
using ReceptionistService.DataAccess.Repositories;

namespace ReceptionistService.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static IServiceCollection AddDIServices(this IServiceCollection services)
    {
        services.AddScoped<ReceptionistRepository>();
        services.AddScoped<IReceptionistService, ReceptionistService.BusinessLogic.Services.ReceptionistService>();

        return services;
    }
}

