using AppointmentsService.Infrastructure.Data;
using AppointmentsService.Infrastructure.Extensions;
using AppointmentsService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();

builder.Services.AddDbContext<AppointmentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<AuthServiceOptions>(
    builder.Configuration.GetSection("AuthService")
    );

builder.Services.AddHttpClient<AuthClientService>();

builder.Services.AddDIServices();

builder.Services.AddAutoMappers();

var app = builder.Build();

app.UseApiPipeline();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppointmentDbContext>();
    context.Database.Migrate();
}

app.Run();
