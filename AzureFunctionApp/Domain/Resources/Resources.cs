using System.Collections.Generic;

namespace AzureFunctionApp.Domain.Resources
{
    public class Resources
    {
        public List<Client> Clients { get; set; } = new List<Client>();
        public List<Campaign> Campaigns { get; set; } = new List<Campaign>();
        public List<Brand> Brands { get; set; } = new List<Brand>();
        public List<Job> Jobs { get; set; } = new List<Job>();
        public List<AdRun> AdRuns { get; set; } = new List<AdRun>();
        public List<Size> Sizes { get; set; } = new List<Size>();
        public List<Service> Services { get; set; } = new List<Service>();
        public List<WeeklyBreakdown> WeeklyBreakdowns { get; set; } = new List<WeeklyBreakdown>();
    }
}
