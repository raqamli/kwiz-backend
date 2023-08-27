using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using X.Kwiz.Api.Entities;

namespace X.Kwiz.Api.Data.Configurations;

public class TechnologiesConfigurationMap : IEntityTypeConfiguration<Technologies>
{
    public void Configure(EntityTypeBuilder<Technologies> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Type).IsRequired();
        builder.Property(b => b.Name).IsRequired();
        builder.Property(b => b.Description).IsRequired();
    }
}