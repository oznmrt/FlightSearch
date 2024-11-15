using FlightSearch.Common.GenericHttpClient.Configs;
using FlightSearch.Common.GenericHttpClient.HttpClients.Interfaces;
using FlightSearch.Common.GenericHttpClient.HttpClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FlightSearch.Common.GenericHttpClient;

public static class HttpClientBootstrapper
{
    public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure ClientConfig from app settings
        services.Configure<ClientConfig>(configuration.GetSection(ClientConfig.SECTION));
        services.AddScoped(sp => sp.GetRequiredService<IOptionsSnapshot<ClientConfig>>().Value);

        // Configure the HttpClient for each provider and add it to DI
        services.AddHttpClient<BaseHttpClient>((_, client) =>
        {
            client.Timeout = TimeSpan.FromSeconds(ClientConfig.DefaultTimeout); // Set default timeout or configure it in your provider
        });

        // Register the custom HTTP clients for HopeAir and AybJet
        services.AddScoped<IHopeAirHttpClient, HopeAirHttpClient>();
        services.AddScoped<IAybJetHttpClient, AybJetHttpClient>();

        return services;
    }
}