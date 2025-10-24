using AppointmentsService.Application.DTOs;
using AppointmentsService.Application.Interfaces;
using AppointmentsService.Domain.Entities;
using AppointmentsService.Domain.Interfaces;
using AutoMapper;

namespace AppointmentsService.Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IMapper _mapper;
    private readonly IAppointmentRepository _repo;

    public AppointmentService(IMapper mapper, IAppointmentRepository repo)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<Guid> CreateAsync(AppointmentDto dto)
    {
        var appointment = _mapper.Map<Appointment>(dto);
        appointment.Id = Guid.NewGuid();
        await _repo.AddAsync(appointment);
        return appointment.Id;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var appointment = await _repo.GetByIdAsync(id);
        if (appointment is null) return false;

        await _repo.DeleteAsync(appointment);
        return true;
    }

    public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
    {
        var appointments = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
    }

    public async Task<AppointmentDto?> GetByIdAsync(Guid id)
    {
        var appointment = await _repo.GetByIdAsync(id);
        return _mapper.Map<AppointmentDto?>(appointment);
    }

    public async Task<bool> UpdateAsync(Guid id, AppointmentDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null) return false;

        _mapper.Map(dto, existing);
        await _repo.UpdateAsync(existing);
        return true;
    }
}
