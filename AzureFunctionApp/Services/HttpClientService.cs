using AzureFunctionApp.Common.Converters;
using AzureFunctionApp.Common.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AzureFunctionApp.Services;

public class HttpClientService : IHttpClientService
{
    private readonly ILogger<HttpClient> _logger;
    private readonly HttpClient _httpClient;

    public HttpClientService(ILogger<HttpClient> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
    }

    public async Task<T> GetAsync<T>(string url) where T : class
    {
        return await GetDeserializedResponseAsync<T>(url);
    }

    public async Task<List<T>> GetRangeAsync<T>(string url) where T : class
    {
        return await GetDeserializedResponseAsync<List<T>>(url);
    }

    private async Task<T> GetDeserializedResponseAsync<T>(string url) where T : class
    {
        var result = default(T);

        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            if (response == null)
            {
                throw new ArgumentNullException();
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
                Converters = 
                {
                    new AdRunConverter() 
                }
            };

            var json = await response.Content.ReadAsStringAsync();
            result = JsonSerializer.Deserialize<T>(json, options);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogInformation(
                $"Request {url} was rejected with status code {ex.StatusCode}. Details: {ex.Message}");
            //throw;
        }
        catch (ArgumentNullException)
        {
            _logger.LogInformation(
                $"Request {url} returned an empty response.");
            //throw;
        }
        catch (JsonException ex)
        {
            _logger.LogInformation(
                $"Request {url} returned an invalid json format. Details: {ex.Message}");
            //throw;
        }

        return result;
    }
}
