using AzureFunctionApp.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureFunctionApp.Domain.Resources;

public class AdRun : EntityBase
{
    [Column(TypeName = "nvarchar(256)")]
    public string CustomId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string Placement { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string MediaType { get; set; }
    public int? Units { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string UnitType { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public string ClientComment { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string BookingComment { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string FinanceComment { get; set; }

    public double? EstimatedAV { get; set; }
    public int? EstimatedCT { get; set; }
    public double? EstimatedCTR { get; set; }
    public double? EstimatedLead { get; set; }

    [Column(TypeName = "nvarchar(5)")]
    public string Currency { get; set; }
    public double? NetNet { get; set; }
    public double? SumRatecard { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public string SalesHouse { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string Site { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string Format { get; set; }

    // Navigation properties
    public string CampaignId { get; set; }
    public Campaign Campaign { get; set; }
    public IEnumerable<WeeklyBreakdown> WeeklyBreakdowns { get; set; }
    public IEnumerable<Size> Sizes { get; set; }
}
