using Dapper;
using ReceptionistService.Domain.Entities;
using ReceptionistService.DataAccess.Data;
using ReceptionistService.Domain.Interfaces;

namespace ReceptionistService.DataAccess.Repositories;

public class ReceptionistRepository : IReceptionistRepository
{
    private readonly DapperContext _context;

    public ReceptionistRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Receptionist>> GetAllAsync()
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Receptionist>("SELECT * FROM Receptionists");
    }

    public async Task<Receptionist?> GetByIdAsync(Guid id)
    {
        using var connection = _context.CreateConnection();
        var sql = "SELECT * FROM Receptionists WHERE Id = @Id";
        return await connection.QueryFirstOrDefaultAsync<Receptionist>(sql, new { Id = id });
    }

    public async Task CreateAsync(Receptionist r)
    {
        using var connection = _context.CreateConnection();
        var sql = """
      INSERT INTO Receptionists (Id, FirstName, LastName, MiddleName)
      VALUES (@Id, @FirstName, @LastName, @MiddleName)
      """;
        await connection.ExecuteAsync(sql, r);
    }

    public async Task UpdateAsync(Receptionist r)
    {
        using var connection = _context.CreateConnection();
        var sql = """
      UPDATE Receptionists
      SET FirstName=@FirstName, LastName=@LastName, MiddleName=@MiddleName
      WHERE Id=@Id
      """;
        await connection.ExecuteAsync(sql, r);
    }

    public async Task DeleteAsync(Guid id)
    {
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync("DELETE FROM Receptionists WHERE Id=@Id", new { Id = id });
    }
}
