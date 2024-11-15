namespace FlightSearch.Common.GenericHttpClient.HttpClients.Interfaces;

public interface IBaseHttpClient
{
    public Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest request, CancellationToken token = default) where TRequest : class where TResponse : class;

    public Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request, CancellationToken token = default) where TRequest : class where TResponse : class;

    public Task<TResponse> GetAsync<TResponse>(string url, CancellationToken token = default) where TResponse : class;

    public Task<TResponse> GetAsync<TRequest, TResponse>(string url, TRequest request, CancellationToken token = default) where TRequest : class where TResponse : class;

    public Task DeleteAsync(string url, CancellationToken token = default);

    public Task<TResponse> DeleteAsync<TResponse>(string url, CancellationToken token = default) where TResponse : class;
}