using AzureFunctionApp.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzureFunctionApp.Persistence.Configurations;
public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.ToTable("Campaigns");
        builder.HasKey(x => x.Id);

        builder
            .HasMany(e => e.AdRuns)
            .WithOne(e => e.Campaign)
            .HasForeignKey(e => e.CampaignId);

        builder
            .HasMany(e => e.Services)
            .WithOne(e => e.Campaign)
            .HasForeignKey(e => e.CampaignId);

        builder
            .HasMany(e => e.Jobs)
            .WithOne(e => e.Campaign)
            .HasForeignKey(e => e.CampaignId);
    }
}
