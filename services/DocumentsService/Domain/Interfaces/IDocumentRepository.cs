using DocumentsService.Domain.Entities;

namespace DocumentsService.Domain.Interfaces;

public interface IDocumentRepository
{
    Task<IEnumerable<Document>> GetAllAsync();
    Task<Document?> GetByIdAsync(Guid id);
    Task AddAsync(Document document);
    Task UpdateAsync(Document document);
    Task DeleteAsync(Document document);
}
