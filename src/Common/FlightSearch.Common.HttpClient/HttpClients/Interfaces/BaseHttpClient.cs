using FlightSearch.Common.Core.Enums;
using FlightSearch.Common.GenericHttpClient.Configs;
using FlightSearch.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace FlightSearch.Common.GenericHttpClient.HttpClients.Interfaces;

public abstract class BaseHttpClient : IBaseHttpClient
{
    protected readonly HttpClient _httpClient;
    protected readonly ClientConfig _config;

    protected ProviderClientConfig _providerConfig
    {
        get
        {
            if (!_config.Providers.TryGetValue(ProviderType, out var providerType))
                throw new Exception($"Missing ProviderClient for {ProviderType}");
            return providerType;
        }
    }

    protected BaseHttpClient(IServiceProvider provider)
    {
        _config = provider.GetRequiredService<ClientConfig>();
        _httpClient = provider.GetRequiredService<HttpClient>();
    }

    public abstract ProviderType ProviderType { get; }

    public async Task<TResponse> DeleteAsync<TResponse>(string url, CancellationToken token = default) where TResponse : class
    {
        var requestUrl = _providerConfig.BaseUrl.CombineUrls(url);
        var response = await _httpClient.DeleteAsync(requestUrl, token);

        // Timeout or failed request check
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TResponse>(responseBody)!;
    }

    public async Task DeleteAsync(string url, CancellationToken token = default)
    {
        var requestUrl = _providerConfig.BaseUrl.CombineUrls(url);
        var response = await _httpClient.DeleteAsync(requestUrl, token);

        // Timeout or failed request check
        response.EnsureSuccessStatusCode();
    }

    public async Task<TResponse> GetAsync<TResponse>(string url, CancellationToken token = default) where TResponse : class
    {
        var requestUrl = _providerConfig.BaseUrl.CombineUrls(url);
        var response = await _httpClient.GetAsync(requestUrl, token);

        // Timeout or failed request check
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TResponse>(responseBody)!;
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request, CancellationToken token = default) where TRequest : class where TResponse : class
    {
        var requestUrl = _providerConfig.BaseUrl.CombineUrls(url);

        var requestBody = JsonConvert.SerializeObject(request);
        var content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(requestUrl, content);

        // Timeout or failed request check
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TResponse>(responseBody)!;
    }

    public async Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest request, CancellationToken token = default) where TRequest : class where TResponse : class
    {
        var requestUrl = _providerConfig.BaseUrl.CombineUrls(url);

        var requestBody = JsonConvert.SerializeObject(request);
        var content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(requestUrl, content);

        // Timeout or failed request check
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TResponse>(responseBody)!;
    }
}