using System.Data;
using Microsoft.Data.SqlClient;

namespace ReceptionistService.Infrastructure.Data;

public class DapperContext
{
    private readonly string _connectionString;

    public DapperContext(string connectionString)
    {
        _connectionString = connectionString
          ?? throw new ArgumentNullException(nameof(connectionString));
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
