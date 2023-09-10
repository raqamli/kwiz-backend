using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kwiz.Api.Entities;

namespace Kwiz.Api.Data.Configurations;
public class TechInterestConfiguration : IEntityTypeConfiguration<TechInterest>
{
    public void Configure(EntityTypeBuilder<TechInterest> builder)
    {
        builder.HasKey(b => b.UserId);
        builder.HasMany(b => b.InterestedTechnologies)
            .WithMany();
    }
}