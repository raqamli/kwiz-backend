using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using X.Kwiz.Api.Entities;

namespace X.Kwiz.Api.Data.Configurations;

public class SubmissionSelectionConfigurationMap : IEntityTypeConfiguration<SubmissionSelection>
{
    public void Configure(EntityTypeBuilder<SubmissionSelection> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.IsSkipped).IsRequired();
        builder.Property(b => b.TimeSpentOnQuestion).IsRequired();

        builder.HasMany(b => b.SelectedOptions)
            .WithOne(b => b.SubmissionSelection)
            .HasForeignKey(b => b.SubmissionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}