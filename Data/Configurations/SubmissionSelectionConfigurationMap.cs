using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kwiz.Api.Entities;

namespace Kwiz.Api.Data.Configurations;

public class SubmissionSelectionConfigurationMap : IEntityTypeConfiguration<SubmissionSelection>
{
    public void Configure(EntityTypeBuilder<SubmissionSelection> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasOne(b => b.Question)
            .WithOne(b => b.SubmissionSelection)
            .HasForeignKey<QuizQuestion>(b => b.SubmissionSelectionId)
            .IsRequired();        
    }
}