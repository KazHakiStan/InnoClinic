using Microsoft.EntityFrameworkCore;
using PatientService.Application.DTOs;
using PatientService.Application.Interfaces;
using PatientService.Domain.Entities;
using PatientService.Infrastructure.Data;

namespace PatientService.Application.Services;

public class PatientService : IPatientService
{
    private readonly PatientDbContext _context;
    public PatientService(PatientDbContext context) => _context = context;

    public async Task<IEnumerable<PatientDto>> GetAllAsync() =>
      await _context.Patients
        .Select(p => new PatientDto
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            MiddleName = p.MiddleName,
            DateOfBirth = p.DateOfBirth,
            IsLinkedToAccount = p.IsLinkedToAccount
        })
        .ToListAsync();

    public async Task<PatientDto?> GetByIdAsync(Guid id)
    {
        var p = await _context.Patients.FindAsync(id);
        return p == null ? null : new PatientDto
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            MiddleName = p.MiddleName,
            DateOfBirth = p.DateOfBirth,
            IsLinkedToAccount = p.IsLinkedToAccount
        };
    }

    public async Task<Guid> CreateAsync(PatientDto dto)
    {
        var patient = new Patient
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            MiddleName = dto.MiddleName,
            DateOfBirth = dto.DateOfBirth,
            IsLinkedToAccount = dto.IsLinkedToAccount
        };
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
        return patient.Id;
    }

    public async Task<bool> UpdateAsync(Guid id, PatientDto dto)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null) return false;

        patient.FirstName = dto.FirstName;
        patient.LastName = dto.LastName;
        patient.MiddleName = dto.MiddleName;
        patient.DateOfBirth = dto.DateOfBirth;
        patient.IsLinkedToAccount = dto.IsLinkedToAccount;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null) return false;

        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
        return true;
    }
}
