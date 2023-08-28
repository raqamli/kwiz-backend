using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using X.Kwiz.Api.Entities;

namespace X.Kwiz.Api.Data.Configurations;

public class QuestionOptionsConfigurationMap : IEntityTypeConfiguration<QuestionOption>
{
    public void Configure(EntityTypeBuilder<QuestionOption> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Content).HasMaxLength(1024).IsRequired();
        builder.Property(b => b.Explanation).HasMaxLength(1024).IsRequired();
    }
}