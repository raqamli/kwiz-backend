using Microsoft.EntityFrameworkCore;

namespace X.Kwiz.Api.Data;

public class KwizDbContext : DbContext
{
    public KwizDbContext(DbContextOptions<KwizDbContext> options) 
        : base(options) { }
}