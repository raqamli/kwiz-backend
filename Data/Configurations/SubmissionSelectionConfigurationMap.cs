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
            .WithMany(b => b.SubmissionSelections)
            .HasForeignKey(b => b.QuestionId)
            .IsRequired();        
    }
}