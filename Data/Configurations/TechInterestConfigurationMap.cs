using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using X.Kwiz.Api.Entities;

namespace X.Kwiz.Api.Data.Configurations;
public class TechInterestConfigurationMap : IEntityTypeConfiguration<TechInterest>
{
    public void Configure(EntityTypeBuilder<TechInterest> builder)
    {
        builder.HasKey(b => b.UserId);
        builder.Property(b => b.Interests).IsRequired();
    }
}