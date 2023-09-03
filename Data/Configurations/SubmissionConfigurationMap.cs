using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kwiz.Api.Entities;

namespace Kwiz.Api.Data.Configurations;

public class SubmissionConfigurationMap : IEntityTypeConfiguration<Submission>
{
    public void Configure(EntityTypeBuilder<Submission> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasOne(b => b.Quiz)
            .WithMany(b => b.Submissions)
            .HasForeignKey(b => b.QuizId)
            .IsRequired();
    }
}