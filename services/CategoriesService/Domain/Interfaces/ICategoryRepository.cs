using CategoryService.Domain.Entities;

namespace CategoryService.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(Guid id);
    Task AddAsync(Category doctor);
    Task UpdateAsync(Category doctor);
    Task DeleteAsync(Category doctor);
}

