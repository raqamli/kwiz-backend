using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using X.Kwiz.Api.Entities;

namespace X.Kwiz.Api.Data.Configurations;

public class TechnologiesConfigurationMap : IEntityTypeConfiguration<Technologies>
{
    public void Configure(EntityTypeBuilder<Technologies> builder)
    {
        builder.Property(b => b.type).IsRequired();
        builder.Property(b => b.Name).IsRequired();
        builder.Property(b => b.Description).IsRequired();
    }
}