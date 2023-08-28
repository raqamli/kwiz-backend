using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using X.Kwiz.Api.Entities;

namespace X.Kwiz.Api.Data.Configurations;

public class SubmissionConfigurationMap : IEntityTypeConfiguration<Submission>
{
    public void Configure(EntityTypeBuilder<Submission> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasMany(b => b.Selections)
            .WithOne(b => b.Submission)
            .HasForeignKey(b => b.SubmissionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}