using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kwiz.Api.Entities;

namespace Kwiz.Api.Data.Configurations;

public class SubmissionSelectionConfigurationMap : IEntityTypeConfiguration<SubmissionSelection>
{
    public void Configure(EntityTypeBuilder<SubmissionSelection> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasMany(b => b.SelectedOptions)
            .WithOne(b => b.SubmissionSelection)
            .HasForeignKey(b => b.SubmissionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}