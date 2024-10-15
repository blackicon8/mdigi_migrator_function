using System.Collections.Generic;

namespace AzureFunctionApp.Domain.DTOs;
public class CampaignsRootDto
{
    public int Count { get; set; }
    public List<CampaignDto> Rows { get; set; } = new List<CampaignDto>();
}
