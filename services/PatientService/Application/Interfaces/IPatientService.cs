using PatientService.Application.DTOs;

namespace PatientService.Application.Interfaces;

public interface IPatientService
{
    Task<IEnumerable<PatientDto>> GetAllAsync();
    Task<PatientDto?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(PatientDto dto);
    Task<bool> UpdateAsync(Guid id, PatientDto dto);
    Task<bool> DeleteAsync(Guid id);
}
