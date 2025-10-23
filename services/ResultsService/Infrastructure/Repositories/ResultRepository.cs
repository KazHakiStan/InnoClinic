using MongoDB.Driver;
using ResultsService.Domain.Entities;
using ResultsService.Domain.Interfaces;
using ResultsService.Infrastructure.Data;

namespace ResultsService.Infrastructure.Respositories;

public class ResultRepository : IResultRepository
{
    private readonly IMongoCollection<Result> _results;

    public ResultRepository(MongoContext context)
    {
        _results = context.Results;
    }

    public async Task CreateAsync(Result result)
    {
        await _results.InsertOneAsync(result);
    }

    public async Task DeleteAsync(Result result)
    {
        await _results.DeleteOneAsync(r => r.Id == result.Id);
    }

    public async Task<IEnumerable<Result>> GetAllAsync()
    {
        return await _results.Find(_ => true).ToListAsync();
    }

    public async Task<Result?> GetByIdAsync(Guid id)
    {
        return await _results.Find(r => r.Id == id).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Result result)
    {
        await _results.ReplaceOneAsync(r => r.Id == result.Id, result);
    }
}
