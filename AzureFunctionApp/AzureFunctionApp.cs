using AzureFunctionApp.Common.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureFunctionApp;

public class AzureFunctionApp
{
    private readonly ILogger<AzureFunctionApp> _logger;
    private readonly IApiManager _apiManager;
    private readonly IMapper _mapper;
    private readonly IResourceRepository _resourceRepository;

    public AzureFunctionApp(
        ILogger<AzureFunctionApp> logger,
        IApiManager apiManager,
        IMapper mapper,
        IResourceRepository resourceRepository
    )
    {
        _logger = logger;
        _apiManager = apiManager;
        _mapper = mapper;
        _resourceRepository = resourceRepository;
    }

    [FunctionName("MDigitalApiQuery")]
    public async Task Run([TimerTrigger("0 0 3 * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timer, ILogger log)
    {
        try
        {
            _logger.LogInformation($"Timer triggered function executed at: {DateTime.Now}");

            var tasks = new List<Task>();

            var campaigns = await _apiManager.GetCampaignsAsync();
            var campaignDetails = await _apiManager.GetCampaignDetailsAsync(campaigns);

            var resources = _mapper.GetResourcesFromCampaignDetails(campaignDetails);

            _resourceRepository.AddResources(resources);

            _logger.LogInformation("Timer triggered function succeded.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Timer trigerred function failed. Message: {ex.Message}");
        }
    }
}
