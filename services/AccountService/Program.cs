using Microsoft.EntityFrameworkCore;
using AccountService.Infrastructure.Data;
using AccountService.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();

builder.Services.AddDbContext<AccountDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDIServices();

builder.Services.AddAutoMappers();

builder.Services.AddMediatRServices();

var app = builder.Build();

app.UseApiPipeline();

app.Run();
