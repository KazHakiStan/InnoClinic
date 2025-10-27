using Microsoft.EntityFrameworkCore;
using ServicesService.Domain.Entities;
using ServicesService.Domain.Interfaces;
using ServicesService.Infrastructure.Data;

namespace ServicesService.Infrastructure.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly ServiceDbContext _context;

    public ServiceRepository(ServiceDbContext context) => _context = context;

    public async Task<IEnumerable<Service>> GetAllAsync() => await _context.Services.ToListAsync();

    public async Task<Service?> GetByIdAsync(Guid id) => await _context.Services.FindAsync(id);

    public async Task AddAsync(Service service)
    {
        _context.Services.Add(service);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Service service)
    {
        _context.Services.Update(service);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Service service)
    {
        _context.Services.Remove(service);
        await _context.SaveChangesAsync();
    }
}

