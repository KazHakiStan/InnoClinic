using Microsoft.EntityFrameworkCore;
using SpecializationService.Domain.Entities;

namespace SpecializationService.Infrastructure.Data;

public class SpecializationDbContext : DbContext
{
    public SpecializationDbContext(DbContextOptions<SpecializationDbContext> options) : base(options) { }

    public DbSet<Specialization> Specializations => Set<Specialization>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Specialization>(entity =>
            {
                entity.ToTable("Specializations");
                entity.HasKey(d => d.Id);
            });
    }
}
