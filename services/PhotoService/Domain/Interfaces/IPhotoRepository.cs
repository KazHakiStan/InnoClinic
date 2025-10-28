using PhotoService.Domain.Entities;

namespace PhotoService.Domain.Interfaces;

public interface IPhotoRepository
{
    Task<IEnumerable<Photo>> GetAllAsync();
    Task<Photo?> GetByIdAsync(Guid id);
    Task AddAsync(Photo doctor);
    Task UpdateAsync(Photo doctor);
    Task DeleteAsync(Photo doctor);
}

