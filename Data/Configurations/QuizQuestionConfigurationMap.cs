using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using X.Kwiz.Api.Entities;

namespace X.Kwiz.Api.Data.Configurations;

public class QuizQuestionConfigurationMap : IEntityTypeConfiguration<QuizQuestion>
{
    public void Configure(EntityTypeBuilder<QuizQuestion> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.TimeLimitSeconds).IsRequired();
        builder.Property(b => b.Content).HasMaxLength(1024).IsRequired();
    }
}