using Microsoft.EntityFrameworkCore;
using SpecializationService.Infrastructure.Data;
using SpecializationService.Infrastructure.Extensions;
using SpecializationService.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();

builder.Services.AddDbContext<SpecializationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<AuthServiceOptions>(
    builder.Configuration.GetSection("AuthService"));

builder.Services.AddHttpClient<AuthClientService>();

builder.Services.AddDIServices();

builder.Services.AddAutoMappers();

builder.Services.AddMediatRServices();

var app = builder.Build();

app.UseApiPipeline();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SpecializationDbContext>();
    context.Database.Migrate();
}

app.Run();
