using Microsoft.EntityFrameworkCore;
using AuthService.Domain.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Data;

namespace AuthService.Infrastructure.Repositories;

public class UserAccountRepository : IUserAccountRepository
{
    private readonly AuthDbContext _context;

    public UserAccountRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(UserAccount userAccount, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(userAccount, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users.AnyAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<UserAccount?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }
}
