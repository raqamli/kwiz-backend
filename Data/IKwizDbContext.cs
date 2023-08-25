using Microsoft.EntityFrameworkCore;
using X.Kwiz.Api.Entities;

namespace X.Kwiz.Api.Data;
public interface IKwizDbContext
{
    DbSet<TechInterest> TechInterests { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}