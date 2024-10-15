using System;
using System.Collections.Generic;

namespace AzureFunctionApp.Domain.DTOs;
public class AdRunDto
{
    public string Id { get; set; }
    public string CampaignId { get; set; }
    public string CustomId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Placement { get; set; }
    public string PricingType { get; set; }
    public int Units { get; set; }
    public string ClientComment { get; set; }
    public string BookingComment { get; set; }
    public string FinanceComment { get; set; }
    public double EstimatedAV { get; set; }
    public int EstimatedCT { get; set; }
    public double? EstimatedCTR { get; set; }
    public double? EstimatedLead { get; set; }
    public double? NetNet { get; set; }
    public double? SumRatecard { get; set; }
    public string AdvertisingCode { get; set; }

    public List<WeeklyBreakdownDto> WeeklyBreakdown { get; set; }
    public SalesHouseDto SalesHouse { get; set; }
    public SiteDto Site { get; set; }
    public FormatDto Format { get; set; }
    public List<SizeDto> Sizes { get; set; }
}
