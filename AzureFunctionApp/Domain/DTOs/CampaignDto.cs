using System;
using System.Collections.Generic;

namespace AzureFunctionApp.Domain.DTOs;

public class CampaignDto
{
    public string Id { get; set; }
    public string CustomId { get; set; }
    public string Campaign { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Planner { get; set; }

    public string Target { get; set; }
    public int Fee { get; set; }
    public string ExchangeCurrency { get; set; }
    public int Buffer { get; set; }
    public double Budget { get; set; }
    public string BudgetType { get; set; }
    public string State { get; set; }
    public int Version { get; set; }
    public int AdServerBuffer { get; set; }
    public int AdServerDiscount { get; set; }
    public int IsoCountryCode { get; set; }
    public DateTime? ArchivedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ClientDto Client { get; set; }
    public BrandDto Brand { get; set; }
    public List<JobDto> Jobs { get; set; }
}
