using AzureFunctionApp.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzureFunctionApp.Persistence.Configurations
{
    public class AdRunConfiguration : IEntityTypeConfiguration<AdRun>
    {
        public void Configure(EntityTypeBuilder<AdRun> builder)
        {
            builder.ToTable("AdRuns");
            builder.HasKey(x => x.Id);

            builder
                .HasMany(e => e.Sizes)
                .WithOne(e => e.AdRun)
                .HasForeignKey(e => e.AdRunId);

            builder
                .HasMany(e => e.WeeklyBreakdowns)
                .WithOne(e => e.AdRun)
                .HasForeignKey(e => e.AdRunId);
        }
    }
}
