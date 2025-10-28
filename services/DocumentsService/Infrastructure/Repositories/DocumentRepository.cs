using Microsoft.EntityFrameworkCore;
using DocumentsService.Domain.Entities;
using DocumentsService.Domain.Interfaces;
using DocumentsService.Infrastructure.Data;

namespace DocumentsService.Infrastructure.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly DocumentDbContext _context;

    public DocumentRepository(DocumentDbContext context) => _context = context;

    public async Task<IEnumerable<Document>> GetAllAsync() => await _context.Documents.ToListAsync();

    public async Task<Document?> GetByIdAsync(Guid id) => await _context.Documents.FindAsync(id);

    public async Task AddAsync(Document doc)
    {
        _context.Documents.Add(doc);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Document doc)
    {
        _context.Documents.Update(doc);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Document doc)
    {
        _context.Documents.Remove(doc);
        await _context.SaveChangesAsync();
    }
}

