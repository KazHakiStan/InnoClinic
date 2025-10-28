using MediatR;
using Microsoft.OpenApi.Models;
using DocumentsService.Domain.Interfaces;
using DocumentsService.Infrastructure.Mapping;
using DocumentsService.Infrastructure.Repositories;

namespace DocumentsService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "DocumentsService", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token (Bearer {token})",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
              {
                new OpenApiSecurityScheme
                {
                  Reference = new OpenApiReference
                  {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                  }
                },
                Array.Empty<string>()
              }
            });
        });

        return services;
    }

    public static IServiceCollection AddDIServices(this IServiceCollection services)
    {
        services.AddScoped<IDocumentRepository, DocumentRepository>();

        return services;
    }

    public static IServiceCollection AddAutoMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        return services;
    }

    public static IServiceCollection AddMediatRServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);
        return services;
    }
}

