using Microsoft.EntityFrameworkCore;
using AccountService.Domain.Entities;

namespace AccountService.Infrastructure.Data;

public class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
    { }

    public DbSet<Account> Accounts => Set<Account>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Accounts");
            entity.HasKey(a => a.Id);
        });
    }
}
