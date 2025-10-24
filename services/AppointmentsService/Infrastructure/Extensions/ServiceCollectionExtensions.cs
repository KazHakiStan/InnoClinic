using AppointmentsService.Application.Interfaces;
using AppointmentsService.Application.Services;
using AppointmentsService.Domain.Interfaces;
using AppointmentsService.Infrastructure.Mapping;
using AppointmentsService.Infrastructure.Repositories;

namespace AppointmentsService.Infrastructure.Extensions;

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
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();

        return services;
    }

    public static IServiceCollection AddAutoMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        return services;
    }
}
