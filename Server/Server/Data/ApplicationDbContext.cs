using Microsoft.EntityFrameworkCore;
using Server.Entities;

namespace Server.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration? configuration)
    : DbContext(options)
{
    public DbSet<AccessRequest> AccessRequests => Set<AccessRequest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(configuration?.GetConnectionString("DefaultConnection"));
    }
}