using DoctorService.Infrastructure.Data;
using DoctorService.Infrastructure.Extensions;
using DoctorService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();

builder.Services.AddDbContext<DoctorDbContext>(options =>
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
    var context = scope.ServiceProvider.GetRequiredService<DoctorDbContext>();
    context.Database.Migrate();
}

app.Run();
