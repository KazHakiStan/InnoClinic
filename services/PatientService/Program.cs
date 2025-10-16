using Microsoft.EntityFrameworkCore;
using PatientService.Infrastructure.Data;
using PatientService.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();

builder.Services.AddDbContext<PatientDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDIServices();

builder.Services.AddAutoMappers();

var app = builder.Build();

app.UseApiPipeline();

app.Run();
