using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using X.Kwiz.Api.Entities;

namespace X.Kwiz.Api.Data.Configurations;

public class QuizConfigurationMap : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Title).HasMaxLength(100).IsRequired();
        builder.Property(b => b.Description).HasMaxLength(1024).IsRequired();
        builder.Property(b => b.OpeningDateTime).IsRequired();
        builder.Property(b => b.ClosingDateTime).IsRequired();
        builder.Property(b => b.Status).IsRequired();
        builder.Property(b => b.IsPublic).IsRequired();
        builder.Property(b => b.Code).IsRequired();
    }
}