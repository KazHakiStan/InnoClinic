using Microsoft.EntityFrameworkCore;
using PatientService.Domain.Entities;

namespace PatientService.Infrastructure.Data;

public class PatientDbContext : DbContext
{
    public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options) { }

    public DbSet<Patient> Patients { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patients");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.FirstName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.LastName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.MiddleName)
                      .HasMaxLength(50);

                entity.Property(p => p.DateOfBirth)
                      .IsRequired();
            });
    }
}
