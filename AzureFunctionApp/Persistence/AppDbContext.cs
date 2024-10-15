using AzureFunctionApp.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AzureFunctionApp.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<AdRun> AdRuns { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<WeeklyBreakdown> WeeklyBreakdowns { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
