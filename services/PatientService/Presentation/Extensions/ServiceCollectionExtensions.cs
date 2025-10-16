using PatientService.Application.Interfaces;
using PatientService.Application.Mapping;
using PatientService.Infrastructure.Repositories;

namespace PatientService.Presentation.Extensions;

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
        services.AddScoped<IPatientService, PatientService.Application.Services.PatientService>();
        services.AddScoped<IPatientRepository, PatientRepository>();

        return services;
    }

    public static IServiceCollection AddAutoMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        return services;
    }
}
