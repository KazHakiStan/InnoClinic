using Microsoft.EntityFrameworkCore;
using PhotoService.Domain.Interfaces;
using PhotoService.Domain.Entities;
using PhotoService.Infrastructure.Data;

namespace PhotoService.Infrastructure.Repositories;

public class PhotoRepository : IPhotoRepository
{
    private readonly PhotoDbContext _context;

    public PhotoRepository(PhotoDbContext context) => _context = context;

    public async Task<IEnumerable<Photo>> GetAllAsync() => await _context.Photos.ToListAsync();

    public async Task<Photo?> GetByIdAsync(Guid id) => await _context.Photos.FindAsync(id);

    public async Task AddAsync(Photo photo)
    {
        _context.Photos.Add(photo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Photo photo)
    {
        _context.Photos.Update(photo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Photo photo)
    {
        _context.Photos.Remove(photo);
        await _context.SaveChangesAsync();
    }
}
