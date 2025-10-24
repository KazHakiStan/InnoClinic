using Microsoft.EntityFrameworkCore;
using AccountService.Domain.Interfaces;
using AccountService.Domain.Entities;
using AccountService.Infrastructure.Data;

namespace AccountService.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AccountDbContext _context;

    public AccountRepository(AccountDbContext context) => _context = context;

    public async Task<IEnumerable<Account>> GetAllAsync() => await _context.Accounts.ToListAsync();

    public async Task<Account?> GetByIdAsync(Guid id) => await _context.Accounts.FindAsync(id);

    public async Task AddAsync(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Account account)
    {
        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Account account)
    {
        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
    }
}

