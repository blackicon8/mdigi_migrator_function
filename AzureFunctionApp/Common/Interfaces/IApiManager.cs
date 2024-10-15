using AzureFunctionApp.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureFunctionApp.Common.Interfaces
{
    public interface IApiManager
    {
        public Task<List<CampaignDto>> GetCampaignsAsync();

        public Task<List<CampaignDetailsDto>> GetCampaignDetailsAsync(IList<CampaignDto> campaigns);
        public Task<CampaignDetailsDto> GetCampaignDetailAsync(string campaignId);
    }
}
