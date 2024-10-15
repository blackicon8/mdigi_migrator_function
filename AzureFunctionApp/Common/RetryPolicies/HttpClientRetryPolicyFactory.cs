using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Net.Http;

namespace AzureFunctionApp.Common.RetryPolicies;

public class HttpClientRetryPolicyFactory
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<HttpClientRetryPolicyFactory> _logger;

    public HttpClientRetryPolicyFactory(
        IConfiguration configuration,
        ILogger<HttpClientRetryPolicyFactory> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public IAsyncPolicy CreateRetryPolicy()
    {
        int retryCount = int.Parse(_configuration["HttpClient:RetrySettings:Count"]);
        int delayInSeconds = int.Parse(_configuration["HttpClient:RetrySettings:Delay"]);

        return Policy
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(
                retryCount: retryCount,
                sleepDurationProvider: attempt => TimeSpan.FromSeconds(delayInSeconds),
                onRetry: (exception, timeSpan, retryAttempt, context) =>
                {
                    _logger.LogWarning(
                        $"Retry attempt {retryAttempt} after {timeSpan.TotalSeconds} seconds. Details: {exception.Message}");
                });
    }
}
