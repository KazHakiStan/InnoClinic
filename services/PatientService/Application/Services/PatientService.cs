using PatientService.Application.DTOs;
using PatientService.Domain.Interfaces;
using PatientService.Application.Interfaces;
using PatientService.Domain.Entities;
using AutoMapper;

namespace PatientService.Application.Services;

public class PatientService : IPatientService
{
    private readonly IMapper _mapper;
    private readonly IPatientRepository _repo;
    public PatientService(IPatientRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientDto>> GetAllAsync()
    {
        var patients = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<PatientDto>>(patients);
    }

    public async Task<PatientDto?> GetByIdAsync(Guid id)
    {
        var patient = await _repo.GetByIdAsync(id);
        return _mapper.Map<PatientDto?>(patient);
    }

    public async Task<Guid> CreateAsync(PatientDto dto)
    {
        var patient = _mapper.Map<Patient>(dto);
        patient.Id = Guid.NewGuid();
        await _repo.AddAsync(patient);
        return patient.Id;
    }

    public async Task<bool> UpdateAsync(Guid id, PatientDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return false;

        _mapper.Map(dto, existing);
        await _repo.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var patient = await _repo.GetByIdAsync(id);
        if (patient == null) return false;

        await _repo.DeleteAsync(patient);
        return true;
    }
}
