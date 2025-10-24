using ResultsService.Domain.Entities;

namespace ResultsService.Domain.Interfaces;

public interface IResultRepository
{
    Task<IEnumerable<Result>> GetAllAsync();
    Task<Result?> GetByIdAsync(Guid id);
    Task CreateAsync(Result result);
    Task UpdateAsync(Result result);
    Task DeleteAsync(Result result);
}
