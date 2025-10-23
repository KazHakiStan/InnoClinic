using Microsoft.EntityFrameworkCore;
using AuthService.Infrastructure.Data;
using AuthService.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDIServices();

builder.Services.AddJwtServices(builder.Configuration);

builder.Services.AddMediatRServices();

var app = builder.Build();

app.UseApiPipeline();

app.Run();
