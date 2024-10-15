using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureFunctionApp.Common.Interfaces;
public interface IHttpClientService
{
    public Task<T> GetAsync<T>(string url) where T : class;
    public Task<List<T>> GetRangeAsync<T>(string url) where T : class;
}
