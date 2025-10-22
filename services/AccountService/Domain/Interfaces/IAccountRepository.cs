using AccountService.Domain.Entities;

namespace AccountService.Domain.Interfaces;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAllAsync();
    Task<Account?> GetByIdAsync(Guid id);
    Task AddAsync(Account account);
    Task UpdateAsync(Account account);
    Task DeleteAsync(Account account);
}
