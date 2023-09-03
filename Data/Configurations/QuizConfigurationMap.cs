using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kwiz.Api.Entities;

namespace Kwiz.Api.Data.Configurations;

public class QuizConfigurationMap : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Title).HasMaxLength(1024).IsRequired();
        builder.Property(b => b.Description).HasMaxLength(1024).IsRequired();

        builder.HasMany(b => b.Questions)
            .WithMany(b => b.Quizzes)
            .UsingEntity(j => j.ToTable("QuizQuizQuestion"));
    }
}