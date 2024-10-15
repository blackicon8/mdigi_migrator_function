using System.Text.Json;
using System.Text.Json.Serialization;
using AzureFunctionApp.Common.Interfaces;

namespace Infrastructure.Services;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _httpClient;

    public HttpClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
    }

    public async Task<List<T>?> GetRangeAsync<T>(string url) where T : class
    {
        var result = new List<T>();
        var response = await _httpClient.GetAsync(url);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.WriteAsString
        };

        if (response != null)
        {
            var json = await response.Content.ReadAsStringAsync();
            result = JsonSerializer.Deserialize<List<T>>(json, options);
        }

        return result;
    }
}
