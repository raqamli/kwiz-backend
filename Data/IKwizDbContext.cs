using Microsoft.EntityFrameworkCore;
using Kwiz.Api.Entities;

namespace Kwiz.Api.Data;
public interface IKwizDbContext
{
    DbSet<TechInterest> TechInterests { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}