using Microsoft.EntityFrameworkCore;
using ServicesService.Domain.Entities;

namespace ServicesService.Infrastructure.Data;

public class ServiceDbContext : DbContext
{
    public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
    { }

    public DbSet<Service> Services => Set<Service>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Services");
            entity.HasKey(a => a.Id);
        });
    }
}
