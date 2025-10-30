using Microsoft.EntityFrameworkCore;
using PhotoService.Infrastructure.Data;
using PhotoService.Infrastructure.Extensions;
using PhotoService.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();

builder.Services.AddDbContext<PhotoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<AuthServiceOptions>(
    builder.Configuration.GetSection("AuthService"));

builder.Services.AddHttpClient<AuthClientService>();

builder.Services.AddDIServices();

builder.Services.AddAutoMappers();

builder.Services.AddMediatRServices();

var app = builder.Build();

app.UseApiPipeline();

app.Run();
