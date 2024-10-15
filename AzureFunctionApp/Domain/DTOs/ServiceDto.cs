using System;

namespace AzureFunctionApp.Domain.DTOs;
public class ServiceDto
{
    public string Id { get; set; }
    public string CampaignId { get; set; }
    public double Price { get; set; }
    public double DiscountPercentage { get; set; }
    public DateTime BuyingPeriodStart { get; set; }
    public DateTime BuyingPeriodEnd { get; set; }
    public int Units { get; set; }
    public string CustomId { get; set; }
    public bool SkipBuying { get; set; }
    public SubServiceDto Service { get; set; }
}
