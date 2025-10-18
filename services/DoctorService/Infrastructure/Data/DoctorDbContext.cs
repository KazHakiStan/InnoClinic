using Microsoft.EntityFrameworkCore;
using DoctorService.Domain.Entities;

namespace DoctorService.Infrastructure.Data;

public class DoctorDbContext : DbContext
{
    public DoctorDbContext(DbContextOptions<DoctorDbContext> options) : base(options) { }

    public DbSet<Doctor> Doctors => Set<Doctor>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctors");
                entity.HasKey(d => d.Id);
                entity.Property(d => d.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(d => d.LastName).IsRequired().HasMaxLength(50);
                entity.Property(d => d.MiddleName).HasMaxLength(50);
                entity.Property(d => d.Status).HasMaxLength(20);
            });
    }
}
