using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kwiz.Api.Entities;

namespace Kwiz.Api.Data.Configurations;

public class TechnologiesConfigurationMap : IEntityTypeConfiguration<Technologies>
{
    public void Configure(EntityTypeBuilder<Technologies> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Type).HasMaxLength(512).IsRequired();
        builder.Property(b => b.Name).HasMaxLength(256).IsRequired();
        builder.Property(b => b.Description).HasMaxLength(1024).IsRequired();
    }
}