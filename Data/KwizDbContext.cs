using System.Reflection;
using Microsoft.EntityFrameworkCore;
using X.Kwiz.Api.Entities;

namespace X.Kwiz.Api.Data;

public class KwizDbContext : DbContext, IKwizDbContext
{
    public KwizDbContext(DbContextOptions<KwizDbContext> options)
        : base(options) { }

    public DbSet<TechInterest> TechInterests { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetDates();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetDates()
    {
        foreach (var entry in ChangeTracker.Entries<IHasTime>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}