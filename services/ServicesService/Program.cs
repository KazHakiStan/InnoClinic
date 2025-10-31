using Microsoft.EntityFrameworkCore;
using ServicesService.Infrastructure.Data;
using ServicesService.Infrastructure.Extensions;
using ServicesService.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();

builder.Services.AddDbContext<ServiceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<AuthServiceOptions>(
    builder.Configuration.GetSection("AuthService")
    );

builder.Services.AddHttpClient<AuthClientService>();

builder.Services.AddDIServices();

builder.Services.AddAutoMappers();

builder.Services.AddMediatRServices();

var app = builder.Build();

app.UseApiPipeline();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ServiceDbContext>();
    context.Database.Migrate();
}

app.Run();
