using Microsoft.EntityFrameworkCore;
using PatientService.Domain.Interfaces;
using PatientService.Domain.Entities;
using PatientService.Infrastructure.Data;

namespace PatientService.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly PatientDbContext _context;

    public PatientRepository(PatientDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Patient>> GetAllAsync() =>
      await _context.Patients.ToListAsync();

    public async Task<Patient?> GetByIdAsync(Guid id) =>
      await _context.Patients.FindAsync(id);

    public async Task AddAsync(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Patient patient)
    {
        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync() =>
      await _context.SaveChangesAsync();
}
