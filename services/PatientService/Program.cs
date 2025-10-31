using Microsoft.EntityFrameworkCore;
using PatientService.Infrastructure.Data;
using PatientService.Infrastructure.Extensions;
using PatientService.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();

builder.Services.AddDbContext<PatientDbContext>(options =>
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
    var context = scope.ServiceProvider.GetRequiredService<PatientDbContext>();
    context.Database.Migrate();
}

app.Run();
