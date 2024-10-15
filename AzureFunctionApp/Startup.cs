using AzureFunctionApp.Common.Constants;
using AzureFunctionApp.Common.Interfaces;
using AzureFunctionApp.Common.RetryPolicies;
using AzureFunctionApp.Persistence;
using AzureFunctionApp.Services;
using AzureFunctionApp.Services.ExceptionHandlers;
using AzureFunctionApp.Services.Mapper;
using AzureFunctionApp.Services.mDigiApiManager;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;

[assembly: FunctionsStartup(typeof(AzureFunctionApp.Startup))]
namespace AzureFunctionApp;

public class Startup : FunctionsStartup
{
    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
    {
        var context = builder.GetContext();

        builder.ConfigurationBuilder
            .SetBasePath(context.ApplicationRootPath)
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
    }

    public override void Configure(IFunctionsHostBuilder builder)
    {
        var configuration = builder.Services
            .BuildServiceProvider()
            .GetRequiredService<IConfiguration>();

        builder.Services.AddHttpClient("AuthorizedClient", client =>
        {
            client.BaseAddress = new Uri(Endpoints.BaseAddress);
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // TODO: Get Bearer token from KeyVault
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", configuration["HttpClient:Authorization:Bearer"]);
        });

        builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
        {
            // TODO: Get connectionstring from KeyVault
            // https://www.c-sharpcorner.com/article/simple-configuration-of-connection-string-through-key-vault2/
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:Azure"], options =>
            {
                options.EnableRetryOnFailure();
            });
        });

        builder.Services.AddSingleton<IHttpClientService, HttpClientService>();
        builder.Services.AddSingleton<IApiManager, ApiManager>();
        builder.Services.AddSingleton<IMapper, Mapper>();
        builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
        builder.Services.AddSingleton<IDbContextExceptionHandler, DbContextExceptionHandler>();

        builder.Services.AddSingleton<HttpClientRetryPolicyFactory>();
    }
}
