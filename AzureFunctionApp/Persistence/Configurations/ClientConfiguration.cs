using AzureFunctionApp.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzureFunctionApp.Persistence.Configurations;
public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
        builder.HasKey(x => x.Id);

        builder
            .HasMany(e => e.Brands)
            .WithOne(e => e.Client)
            .HasForeignKey(e => e.ClientId);
    }
}
