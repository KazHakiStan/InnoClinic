using Microsoft.EntityFrameworkCore;
using OfficesService.Domain.Interfaces;
using OfficesService.Domain.Entities;
using OfficesService.Infrastructure.Data;

namespace OfficesService.Infrastructure.Repositories;

public class OfficeRepository : IOfficeRepository
{
    private readonly OfficeDbContext _context;

    public OfficeRepository(OfficeDbContext context) => _context = context;

    public async Task<IEnumerable<Office>> GetAllAsync() => await _context.Accounts.ToListAsync();

    public async Task<Office?> GetByIdAsync(Guid id) => await _context.Accounts.FindAsync(id);

    public async Task AddAsync(Office account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Office account)
    {
        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Office account)
    {
        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
    }
}

