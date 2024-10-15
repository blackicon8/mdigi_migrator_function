using System.Collections.Generic;

namespace AzureFunctionApp.Domain.DTOs;
public class CampaignDetailsDto
{
    public CampaignDto Campaign { get; set; }
    public List<AdRunDto> AdRuns { get; set; }
    public List<ServiceDto> Services { get; set; }
}
