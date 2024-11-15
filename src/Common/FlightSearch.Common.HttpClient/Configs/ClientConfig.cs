using FlightSearch.Common.Core.Enums;

namespace FlightSearch.Common.GenericHttpClient.Configs;

public class ClientConfig
{
    public static readonly string SECTION = $"HttpClients";

    public static readonly int DefaultTimeout = 30 * 1000;
    public Dictionary<ProviderType, ProviderClientConfig> Providers { get; set; } = [];
}

public class ProviderClientConfig
{
    public string BaseUrl { get; set; } = default!;
    public int? Timeout { get; set; } = ClientConfig.DefaultTimeout;
}