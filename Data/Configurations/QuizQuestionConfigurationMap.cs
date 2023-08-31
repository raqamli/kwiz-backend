using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kwiz.Api.Entities;

namespace Kwiz.Api.Data.Configurations;

public class QuizQuestionConfigurationMap : IEntityTypeConfiguration<QuizQuestion>
{
    public void Configure(EntityTypeBuilder<QuizQuestion> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Content).HasMaxLength(1024).IsRequired();
    }
}