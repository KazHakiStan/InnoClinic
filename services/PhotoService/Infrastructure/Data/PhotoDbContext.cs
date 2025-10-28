using Microsoft.EntityFrameworkCore;
using PhotoService.Domain.Entities;

namespace PhotoService.Infrastructure.Data;

public class PhotoDbContext : DbContext
{
    public PhotoDbContext(DbContextOptions<PhotoDbContext> options) : base(options) { }

    public DbSet<Photo> Photos => Set<Photo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("Photos");
                entity.HasKey(d => d.Id);
            });
    }
}
