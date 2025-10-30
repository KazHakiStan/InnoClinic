using Microsoft.EntityFrameworkCore;
using SpecializationService.Domain.Interfaces;
using SpecializationService.Domain.Entities;
using SpecializationService.Infrastructure.Data;

namespace SpecializationService.Infrastructure.Repositories;

public class SpecializationRepository : ISpecializationRepository
{
    private readonly SpecializationDbContext _context;

    public SpecializationRepository(SpecializationDbContext context) => _context = context;

    public async Task<IEnumerable<Specialization>> GetAllAsync() => await _context.Specializations.ToListAsync();

    public async Task<Specialization?> GetByIdAsync(Guid id) => await _context.Specializations.FindAsync(id);

    public async Task AddAsync(Specialization spec)
    {
        _context.Specializations.Add(spec);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Specialization spec)
    {
        _context.Specializations.Update(spec);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Specialization spec)
    {
        _context.Specializations.Remove(spec);
        await _context.SaveChangesAsync();
    }
}
