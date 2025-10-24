using AppointmentsService.Application.DTOs;

namespace AppointmentsService.Application.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDto>> GetAllAsync();
    Task<AppointmentDto?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(AppointmentDto dto);
    Task<bool> UpdateAsync(Guid id, AppointmentDto dto);
    Task<bool> DeleteAsync(Guid id);
}
