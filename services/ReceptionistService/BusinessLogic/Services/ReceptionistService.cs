using ReceptionistService.Domain.Entities;
using ReceptionistService.BusinessLogic.Interfaces;
using ReceptionistService.DataAccess.Repositories;

namespace ReceptionistService.BusinessLogic.Services;

public class ReceptionistService : IReceptionistService
{
    private readonly ReceptionistRepository _repo;

    public ReceptionistService(ReceptionistRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Receptionist>> GetAllAsync() => await _repo.GetAllAsync();

    public async Task<Receptionist?> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);

    public async Task CreateAsync(Receptionist receptionist)
    {
        receptionist.Id = Guid.NewGuid();
        await _repo.CreateAsync(receptionist);
    }

    public async Task UpdateAsync(Receptionist receptionist)
    {
        await _repo.UpdateAsync(receptionist);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repo.DeleteAsync(id);
    }
}
