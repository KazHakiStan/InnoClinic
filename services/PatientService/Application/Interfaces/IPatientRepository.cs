using PatientService.Domain.Entities;

namespace PatientService.Application.Interfaces;

public interface IPatientRepository
{
    Task<IEnumerable<Patient>> GetAllAsync();
    Task<Patient?> GetByIdAsync(Guid id);
    Task AddAsync(Patient patient);
    Task UpdateAsync(Patient patient);
    Task DeleteAsync(Patient patient);
    Task SaveChangesAsync();
}
