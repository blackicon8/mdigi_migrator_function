using AzureFunctionApp.Common.Extensions;
using AzureFunctionApp.Common.Interfaces;
using AzureFunctionApp.Domain.DTOs;
using AzureFunctionApp.Domain.Resources;
using System.Collections.Generic;
using System.Linq;

namespace AzureFunctionApp.Services.Mapper;
public class Mapper : IMapper
{
    public Resources GetResourcesFromCampaignDetails(IList<CampaignDetailsDto> campaignDetails)
    {
        var resources = new Resources();

        resources.Clients = GetClientsFromCampaignDetails(campaignDetails);
        resources.Campaigns = GetCampaignsFromCampaignDetails(campaignDetails);
        resources.Brands = GetBrandsFromCampaignDetails(campaignDetails);
        resources.AdRuns = GetAdRunsFromCampaignDetails(campaignDetails);
        resources.Sizes = GetSizesFromCampaignDetails(campaignDetails);
        resources.Jobs = GetJobsFromCampaignDetails(campaignDetails);
        resources.Services = GetServicesFromCampaignDetails(campaignDetails);
        resources.WeeklyBreakdowns = GetWeeklyBreakdownsFromCampaignDetails(campaignDetails);

        return resources;
    }

    public List<WeeklyBreakdown> GetWeeklyBreakdownsFromCampaignDetails(IList<CampaignDetailsDto> campaignDetails)
    {
        var weeklyBreakdowns = new List<WeeklyBreakdown>();

        var adRunDtos = campaignDetails
                        .SelectMany(cd => cd.AdRuns)
                        .ToList();

        foreach (var adRun in adRunDtos)
        {
            var adRunId = adRun.Id;
            var customId = adRun.CustomId;

            var adRunUnits = adRun.Units;
            var adRunNetNet = adRun.NetNet;

            foreach (var weeklyBreakdownDto in adRun.WeeklyBreakdown)
            {
                var weeklyBreakdownUnits = weeklyBreakdownDto.Units;

                var weeklyBreakdown = new WeeklyBreakdown
                {
                    Year = weeklyBreakdownDto.Year,
                    Week = weeklyBreakdownDto.Week,
                    Units = weeklyBreakdownUnits,
                    NetNet = MapperExtensions.GetWeeklyBreakdownNetNet(adRunUnits, adRunNetNet, weeklyBreakdownUnits),
                    AdRunId = adRunId,
                    CustomId = customId
                };

                weeklyBreakdowns.Add(weeklyBreakdown);
            }
        }

        return weeklyBreakdowns;
    }

    public List<Service> GetServicesFromCampaignDetails(IList<CampaignDetailsDto> campaignDetails)
    {
        var services = new List<Service>();

        var serviceDtos = campaignDetails
                            .SelectMany(cd => cd.Services)
                            .ToList();

        foreach (var serviceDto in serviceDtos)
        {
            services.Add(new Service
            {
                Id = serviceDto.Id,
                CustomId = serviceDto.CustomId,
                Price = serviceDto.Price,
                DiscountPercentage = serviceDto.DiscountPercentage,
                BuyingPeriodStart = serviceDto.BuyingPeriodStart,
                BuyingPeriodEnd = serviceDto.BuyingPeriodEnd,
                Units = serviceDto.Units,
                SkipBuying = serviceDto.SkipBuying,
                ServiceId = serviceDto.Service.Id,
                ServiceName = serviceDto.Service.Name,
                DealerId = serviceDto.Service.DealerId,
                MediumId = serviceDto.Service.MediumId,
                TechnicalCostId = serviceDto.Service.TechnicalCostId,
                AdvertisingCode = serviceDto.Service.AdvertisingCode,
                AllowInvoiceOverride = serviceDto.Service.AllowInvoiceOverride,
                AgencyId = serviceDto.Service.AgencyId,
                CampaignId = serviceDto.CampaignId
            });
        }

        return services;
    }

    public List<Job> GetJobsFromCampaignDetails(IList<CampaignDetailsDto> campaignDetails)
    {
        var jobs = new List<Job>();

        var jobDtos = campaignDetails
                        .Select(cd => cd.Campaign)
                        .SelectMany(ca => ca.Jobs)
                        .ToList();

        foreach (var jobDto in jobDtos)
        {
            jobs.Add(new Job
            {
                Id = jobDto.Id,
                JobId = jobDto.JobId,
                Name = jobDto.Name,
                Code = jobDto.Code,
                Type = jobDto.JobType,
                ChannelId = jobDto.ChannelId,
                CampaignId = jobDto.CampaignId
            });
        }

        return jobs;
    }

    public List<Size> GetSizesFromCampaignDetails(IList<CampaignDetailsDto> campaignDetails)
    {
        var sizes = new List<Size>();

        var adRunDtos = campaignDetails
                        .SelectMany(cd => cd.AdRuns)
                        .ToList();

        foreach (var adRun in adRunDtos)
        {
            var adRunId = adRun.Id;

            foreach (var sizeDto in adRun.Sizes)
            {
                sizes.Add(new Size
                {
                    SizeId = sizeDto.Id,
                    Name = sizeDto.Name,
                    IsCustom = sizeDto.IsCustom,
                    FormatId = sizeDto.FormatId,
                    AdRunId = adRunId
                });
            }
        }

        return sizes
                .GroupBy(x => x.Id)
                .Select(x => x.First())
                .ToList();
    }

    public List<AdRun> GetAdRunsFromCampaignDetails(IList<CampaignDetailsDto> campaignDetails)
    {
        var adRuns = new List<AdRun>();

        var adRunDtos = campaignDetails
                        .SelectMany(cd => cd.AdRuns)
                        .ToList();

        foreach (var adRunDto in adRunDtos)
        {
            adRuns.Add(new AdRun
            {
                Id = adRunDto.Id,
                CustomId = adRunDto.CustomId,
                StartDate = adRunDto.StartDate,
                EndDate = adRunDto.EndDate,
                Placement = adRunDto.Placement,
                MediaType = MapperExtensions.GetMediaType(adRunDto.AdvertisingCode),
                Units = adRunDto.Units,
                UnitType = MapperExtensions.GetUnitType(adRunDto.PricingType),
                ClientComment = adRunDto.ClientComment,
                BookingComment = adRunDto.BookingComment,
                FinanceComment = adRunDto.FinanceComment,
                EstimatedAV = adRunDto.EstimatedAV,
                EstimatedCT = adRunDto.EstimatedCT,
                EstimatedCTR = adRunDto.EstimatedCTR,
                EstimatedLead = adRunDto.EstimatedLead,
                Currency = MapperExtensions.GetCurrency(adRunDto.PricingType),
                NetNet = adRunDto.NetNet,
                SalesHouse = adRunDto.SalesHouse != null ? adRunDto.SalesHouse.Name : null,
                Site = adRunDto.Site != null ? adRunDto.Site.Name : null,
                Format = adRunDto.Format != null ? adRunDto.Format.Name : null,
                CampaignId = adRunDto.CampaignId
            });
        }

        return adRuns;
    }

    public List<Brand> GetBrandsFromCampaignDetails(IList<CampaignDetailsDto> campaignDetails)
    {
        var brands = new List<Brand>();

        var brandDtos = campaignDetails
                        .Select(cd => cd.Campaign)
                        .Select(cd => cd.Brand)
                        .ToList();

        foreach (var brandDto in brandDtos)
        {
            brands.Add(new Brand
            {
                Id = brandDto.Id,
                Name = brandDto.Name,
                ClientId = brandDto.ClientId
            });
        }

        return brands
                .GroupBy(x => x.Id)
                .Select(x => x.First())
                .ToList();
    }

    public List<Campaign> GetCampaignsFromCampaignDetails(IList<CampaignDetailsDto> campaignDetails)
    {
        var campaigns = new List<Campaign>();

        var campaignDtos = campaignDetails
                            .Select(cd => cd.Campaign)
                            .ToList();

        foreach (var campaignDto in campaignDtos)
        {
            campaigns.Add(new Campaign
            {
                Id = campaignDto.Id,
                CustomId = campaignDto.CustomId,
                Name = campaignDto.Campaign,
                StartDate = campaignDto.StartDate,
                EndDate = campaignDto.EndDate,
                Planner = campaignDto.Planner,
                Budget = campaignDto.Budget,
                BudgetType = campaignDto.BudgetType,
                State = campaignDto.State,
                Version = campaignDto.Version,
                BrandId = campaignDto.Brand.Id,
                CreatedAt = campaignDto.CreatedAt,
                UpdatedAt = campaignDto.UpdatedAt,
                ArchivedAt = campaignDto.ArchivedAt
            });
        }

        return campaigns
                .GroupBy(x => x.Id)
                .Select(x => x.First())
                .ToList();
    }

    public List<Client> GetClientsFromCampaignDetails(IList<CampaignDetailsDto> campaignDetails)
    {
        var clients = new List<Client>();

        var clientDtos = campaignDetails
                            .Select(cd => cd.Campaign)
                            .Select(ca => ca.Client)
                            .ToList();

        foreach (var clientDto in clientDtos)
        {
            clients.Add(new Client
            {
                Id = clientDto.Id,
                Name = clientDto.Name,
            });
        }

        return clients
                .GroupBy(x => x.Id)
                .Select(x => x.First())
                .ToList();
    }
}
