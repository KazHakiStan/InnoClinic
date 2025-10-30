using ServicesService.Domain.Entities;

namespace ServicesService.Domain.Interfaces;

public interface IServiceRepository
{
    Task<IEnumerable<Service>> GetAllAsync();
    Task<Service?> GetByIdAsync(Guid id);
    Task AddAsync(Service service);
    Task UpdateAsync(Service service);
    Task DeleteAsync(Service service);
}
