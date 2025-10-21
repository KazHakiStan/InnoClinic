using ReceptionistService.DataAccess.Data;

namespace ReceptionistService.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDapperContext(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton(new DapperContext(connectionString));

        return services;
    }
}

