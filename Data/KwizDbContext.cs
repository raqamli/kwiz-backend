using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using X.Kwiz.Api.Entities;

namespace X.Kwiz.Api.Data;

public class KwizDbContext : DbContext, IKwizDbContext
{
    public KwizDbContext(DbContextOptions<KwizDbContext> options)
        : base(options)
    {
        ChangeTracker.StateChanged += OnStateChanged;
    }

    public DbSet<TechInterest> TechInterests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => base.SaveChangesAsync(cancellationToken);

    private void OnStateChanged(object sender, EntityStateChangedEventArgs e)
    {
        if (e.Entry.Entity is IHasTime hasTimestamp)
            if(e.NewState == EntityState.Added)
            {
                hasTimestamp.CreatedAt = DateTime.UtcNow;
                hasTimestamp.UpdatedAt = DateTime.UtcNow;
            }
            else if(e.NewState == EntityState.Modified)
                hasTimestamp.UpdatedAt = DateTime.UtcNow;
    }
}