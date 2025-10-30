using SpecializationService.Domain.Entities;

namespace SpecializationService.Domain.Interfaces;

public interface ISpecializationRepository
{
    Task<IEnumerable<Specialization>> GetAllAsync();
    Task<Specialization?> GetByIdAsync(Guid id);
    Task AddAsync(Specialization doctor);
    Task UpdateAsync(Specialization doctor);
    Task DeleteAsync(Specialization doctor);
}

