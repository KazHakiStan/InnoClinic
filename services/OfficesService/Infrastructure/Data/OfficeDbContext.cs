using Microsoft.EntityFrameworkCore;
using OfficesService.Domain.Entities;

namespace OfficesService.Infrastructure.Data;

public class OfficeDbContext : DbContext
{
    public OfficeDbContext(DbContextOptions<OfficeDbContext> options) : base(options)
    { }

    public DbSet<Office> Accounts => Set<Office>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Office>(entity =>
        {
            entity.ToTable("Offices");
            entity.HasKey(a => a.Id);
        });
    }
}
