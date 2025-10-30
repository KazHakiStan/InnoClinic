using OfficesService.Domain.Entities;

namespace OfficesService.Domain.Interfaces;

public interface IOfficeRepository
{
    Task<IEnumerable<Office>> GetAllAsync();
    Task<Office?> GetByIdAsync(Guid id);
    Task AddAsync(Office office);
    Task UpdateAsync(Office office);
    Task DeleteAsync(Office office);
}
