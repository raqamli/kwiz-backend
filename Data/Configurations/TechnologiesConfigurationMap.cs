using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kwiz.Api.Entities;
using System.Text.Json;

namespace Kwiz.Api.Data.Configurations;

public class TechnologiesConfigurationMap : IEntityTypeConfiguration<Technology>
{
    public void Configure(EntityTypeBuilder<Technology> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(b => b.Type).HasMaxLength(512).IsRequired();
        builder.Property(b => b.Name).HasMaxLength(256).IsRequired();
        builder.Property(b => b.Description).HasMaxLength(1024).IsRequired();
        
        using var stream = File.Open(Path.Combine(Directory.GetCurrentDirectory(), "staticFiles/technologies.json"), FileMode.Open);
        var entities = JsonSerializer.Deserialize<IEnumerable<Technology>>(stream);
        builder.HasData(entities);
    }
}