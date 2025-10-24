using AppointmentsService.Infrastructure.Data;
using AppointmentsService.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();

builder.Services.AddDbContext<AppointmentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDIServices();

builder.Services.AddAutoMappers();

var app = builder.Build();

app.UseApiPipeline();

app.Run();
