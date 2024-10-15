using AzureFunctionApp.Domain.DTOs;
using AzureFunctionApp.Domain.Resources;
using System.Collections.Generic;

namespace AzureFunctionApp.Common.Interfaces;
public interface IMapper
{
    public Resources GetResourcesFromCampaignDetails(IList<CampaignDetailsDto> campaignDetails);
}
