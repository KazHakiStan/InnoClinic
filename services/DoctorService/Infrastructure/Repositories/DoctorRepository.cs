using Microsoft.EntityFrameworkCore;
using DoctorService.Domain.Interfaces;
using DoctorService.Domain.Entities;
using DoctorService.Infrastructure.Data;

namespace DoctorService.Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly DoctorDbContext _context;

    public DoctorRepository(DoctorDbContext context) => _context = context;

    public async Task<IEnumerable<Doctor>> GetAllAsync() => await _context.Doctors.ToListAsync();

    public async Task<Doctor?> GetByIdAsync(Guid id) => await _context.Doctors.FindAsync(id);

    public async Task AddAsync(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Doctor doctor)
    {
        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
    }
}
