using Microsoft.EntityFrameworkCore;
using CategoryService.Domain.Interfaces;
using CategoryService.Domain.Entities;
using CategoryService.Infrastructure.Data;

namespace CategoryService.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly CategoryDbContext _context;

    public CategoryRepository(CategoryDbContext context) => _context = context;

    public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.ToListAsync();

    public async Task<Category?> GetByIdAsync(Guid id) => await _context.Categories.FindAsync(id);

    public async Task AddAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}
