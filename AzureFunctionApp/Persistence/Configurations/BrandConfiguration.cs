using AzureFunctionApp.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzureFunctionApp.Persistence.Configurations;
public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands");
        builder.HasKey(x => x.Id);

        builder
            .HasMany(e => e.Campaigns)
            .WithOne(e => e.Brand)
            .HasForeignKey(e => e.BrandId);
    }
}
