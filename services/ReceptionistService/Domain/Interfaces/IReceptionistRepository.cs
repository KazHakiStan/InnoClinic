using ReceptionistService.Domain.Entities;

namespace ReceptionistService.Domain.Interfaces;

public interface IReceptionistRepository
{
    public Task<IEnumerable<Receptionist>> GetAllAsync();

    public Task<Receptionist?> GetByIdAsync(Guid id);

    public Task CreateAsync(Receptionist r);

    public Task UpdateAsync(Receptionist r);

    public Task DeleteAsync(Guid id);
}

