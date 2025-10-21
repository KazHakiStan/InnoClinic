using ReceptionistService.Domain.Entities;

namespace ReceptionistService.BusinessLogic.Interfaces;

public interface IReceptionistService
{
    Task<IEnumerable<Receptionist>> GetAllAsync();
    Task<Receptionist?> GetByIdAsync(Guid id);
    Task CreateAsync(Receptionist receptionist);
    Task UpdateAsync(Receptionist receptionist);
    Task DeleteAsync(Guid id);
}
