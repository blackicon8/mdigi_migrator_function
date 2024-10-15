using AzureFunctionApp.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureFunctionApp.Domain.Resources;

public class Service : EntityBase
{
    [Column(TypeName = "nvarchar(256)")]
    public string CustomId { get; set; }

    public double Price { get; set; }
    public double DiscountPercentage { get; set; }
    public DateTime BuyingPeriodStart { get; set; }
    public DateTime BuyingPeriodEnd { get; set; }
    public int Units { get; set; }
    public bool SkipBuying { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string ServiceId { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string ServiceName { get; set; }
    public int DealerId { get; set; }
    public int MediumId { get; set; }
    public int TechnicalCostId { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string AdvertisingCode { get; set; }
    public bool AllowInvoiceOverride { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string AgencyId { get; set; }

    // Navigation properties
    public string CampaignId { get; set; }
    public Campaign Campaign { get; set; }
}
