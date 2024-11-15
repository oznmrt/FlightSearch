﻿using FlightSearch.Common.Core.Enums;
using FlightSearch.Common.GenericHttpClient.Configs;
using FlightSearch.Common.GenericHttpClient.Extensions;
using FlightSearch.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace FlightSearch.Common.GenericHttpClient.HttpClients.Interfaces;

public abstract class BaseHttpClient : IBaseHttpClient
{
    protected readonly HttpClient _httpClient;
    protected readonly ClientConfig _config;

    protected ProviderClientConfig ProviderConfig
    {
        get
        {
            if (!_config.Providers.TryGetValue(ProviderType, out var providerType))
                throw new InvalidOperationException($"Missing ProviderClient for {ProviderType}");
            return providerType;
        }
    }

    protected BaseHttpClient(IServiceProvider provider)
    {
        _config = provider.GetRequiredService<ClientConfig>();
        _httpClient = provider.GetRequiredService<HttpClient>();

        _httpClient.Timeout = TimeSpan.FromMilliseconds(ProviderConfig.Timeout.HasValue ? ProviderConfig.Timeout.Value : ClientConfig.DefaultTimeout);
    }

    public abstract ProviderType ProviderType { get; }

    public async Task<TResponse> DeleteAsync<TResponse>(string url, CancellationToken token = default) where TResponse : class
    {
        var requestUrl = ProviderConfig.BaseUrl.CombineUrls(url);
        var response = await _httpClient.DeleteAsync(requestUrl, token);

        // Timeout or failed request check
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync(token);
        return JsonConvert.DeserializeObject<TResponse>(responseBody)!;
    }

    public async Task DeleteAsync(string url, CancellationToken token = default)
    {
        var requestUrl = ProviderConfig.BaseUrl.CombineUrls(url);
        var response = await _httpClient.DeleteAsync(requestUrl, token);

        // Timeout or failed request check
        response.EnsureSuccessStatusCode();
    }

    public async Task<TResponse> GetAsync<TResponse>(string url, CancellationToken token = default) where TResponse : class
    {
        var requestUrl = ProviderConfig.BaseUrl.CombineUrls(url);
        var response = await _httpClient.GetAsync(requestUrl, token);

        // Timeout or failed request check
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync(token);
        return JsonConvert.DeserializeObject<TResponse>(responseBody)!;
    }

    public async Task<TResponse> GetAsync<TRequest, TResponse>(string url, TRequest request, CancellationToken token = default) where TRequest : class where TResponse : class
    {
        var requestUrl = ProviderConfig.BaseUrl.CombineUrls(url);
        var response = await _httpClient.GetAsync($"{requestUrl}?{request.ToQueryString()}", token);

        // Timeout or failed request check
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync(token);
        return JsonConvert.DeserializeObject<TResponse>(responseBody)!;
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request, CancellationToken token = default) where TRequest : class where TResponse : class
    {
        var requestUrl = ProviderConfig.BaseUrl.CombineUrls(url);

        var requestBody = JsonConvert.SerializeObject(request);
        var content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(requestUrl, content, token);

        // Timeout or failed request check
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync(token);
        return JsonConvert.DeserializeObject<TResponse>(responseBody)!;
    }

    public async Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest request, CancellationToken token = default) where TRequest : class where TResponse : class
    {
        var requestUrl = ProviderConfig.BaseUrl.CombineUrls(url);

        var requestBody = JsonConvert.SerializeObject(request);
        var content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(requestUrl, content, token);

        // Timeout or failed request check
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync(token);
        return JsonConvert.DeserializeObject<TResponse>(responseBody)!;
    }
}