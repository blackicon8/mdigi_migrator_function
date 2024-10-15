using AzureFunctionApp.Common.Constants;
using AzureFunctionApp.Common.Extensions;
using AzureFunctionApp.Common.Interfaces;
using AzureFunctionApp.Common.RetryPolicies;
using AzureFunctionApp.Domain.DTOs;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureFunctionApp.Services.mDigiApiManager;

public class ApiManager : IApiManager
{
    private readonly IHttpClientService _httpClientService;
    private readonly IAsyncPolicy _httpClientRetryPolicy;

    public ApiManager(
        IHttpClientService httpClientService,
        HttpClientRetryPolicyFactory httpClientRetryPolicy)
    {
        _httpClientService = httpClientService;
        _httpClientRetryPolicy = httpClientRetryPolicy.CreateRetryPolicy();
    }

    public ApiManagerOptions Options { get; set; } = new ApiManagerOptions();

    public async Task<List<CampaignDto>> GetCampaignsAsync()
    {
        var campaigns = new List<CampaignDto>();
        var offset = 0;

        while (true)
        {
            var endpoint = Endpoints.Campaigns
                            .AddLimit(Options.Limit)
                            .AddOffset(offset)
                            .AddParameter("startDate", "2024-08-01")
                            .AddParameter("endDate", "2024-12-31")
                            .AddParameter("dateRangeOption", "between");

            var response = await _httpClientRetryPolicy.ExecuteAsync(async () =>
                await _httpClientService.GetAsync<CampaignsRootDto>(endpoint));

            campaigns.AddRange(response.Rows);

            if (response.Rows.Count < Options.Limit) { break; }

            offset += Options.Limit;
        }

        return campaigns;
    }

    public async Task<List<CampaignDetailsDto>> GetCampaignDetailsAsync(IList<CampaignDto> campaigns)
    {
        return await GetRawDataByCampaignsAsync(campaigns, GetCampaignDetailAsync);
    }

    public async Task<CampaignDetailsDto> GetCampaignDetailAsync(string campaignId)
    {
        var endpoint = Endpoints.AdRuns
                        .AddSegment(campaignId)
                        .AddParameter("include", new string[] { "adruns", "services" })
                        .AddParameter("withDerivedValues", "true");

        return await _httpClientRetryPolicy.ExecuteAsync(async () =>
            await _httpClientService.GetAsync<CampaignDetailsDto>(endpoint)
        );
    }

    private async Task<List<T>> GetRawDataByCampaignsAsync<T>(IList<CampaignDto> campaigns, Func<string, Task<List<T>>> callback)
    {
        var tasks = new List<Task<List<T>>>();

        foreach (var campaign in campaigns)
        {
            tasks.Add(callback(campaign.Id));
        }

        var results = await Task.WhenAll(tasks);

        return results
            .SelectMany(results => results)
            .ToList();
    }

    private async Task<List<T>> GetRawDataByCampaignsAsync<T>(IList<CampaignDto> campaigns, Func<string, Task<T>> callback)
    {
        var tasks = new List<Task<T>>();

        foreach (var campaign in campaigns)
        {
            tasks.Add(callback(campaign.Id));
        }

        var results = await Task.WhenAll(tasks);

        return results
            .Select(results => results)
            .Where(results => results != null)
            .ToList();
    }
}
