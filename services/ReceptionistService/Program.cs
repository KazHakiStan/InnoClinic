using Dapper;
using ReceptionistService.DataAccess.Data;
using ReceptionistService.DataAccess.Extensions;
using ReceptionistService.Infrastructure.Services;
using ReceptionistService.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
  ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.Configure<AuthServiceOptions>(
    builder.Configuration.GetSection("AuthService")
    );

builder.Services.AddHttpClient<AuthClientService>();

builder.Services.AddApiServices();

builder.Services.AddDapperContext(connectionString);

builder.Services.AddDIServices();

var app = builder.Build();

app.UseApiPipeline();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DapperContext>();
    using var connection = context.CreateConnection();
    var sql = @"
    If NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Receptionists')
    BEGIN
      CREATE TABLE Receptionists
      (
        Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
        FirstName NVARCHAR(100) NOT NULL,
        LastName NVARCHAR(100) NOT NULL,
        MiddleName NVARCHAR(100) NULL,
        AccountId UNIQUEIDENTIFIER NOT NULL,
        OfficeId UNIQUEIDENTIFIER NOT NULL
      )
    END";

    connection.Execute(sql);
}

app.Run();
