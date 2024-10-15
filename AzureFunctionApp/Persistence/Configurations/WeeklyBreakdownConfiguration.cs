using AzureFunctionApp.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzureFunctionApp.Persistence.Configurations;
public class WeeklyBreakdownConfiguration : IEntityTypeConfiguration<WeeklyBreakdown>
{
    public void Configure(EntityTypeBuilder<WeeklyBreakdown> builder)
    {
        builder.ToTable("WeeklyBreakdowns");
        builder.HasKey(x => x.Id);

        builder
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
    }
}
