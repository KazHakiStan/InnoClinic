using ReceptionistService.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
  ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddApiServices();

builder.Services.AddDapperContext(connectionString);

builder.Services.AddDIServices();

var app = builder.Build();

app.UseApiPipeline();

app.Run();
