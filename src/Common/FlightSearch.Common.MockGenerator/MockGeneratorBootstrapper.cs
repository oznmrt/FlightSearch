using Bogus;
using FlightSearch.Common.Application.DTOs;
using FlightSearch.Common.MockGenerator.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace FlightSearch.Common.MockGenerator;

public static class MockGeneratorBootstrapper
{
    public static IServiceCollection AddSoapMockGenerator(this IServiceCollection services)
    {
        services.AddScoped<IProviderMockGenerator, SoapProviderMockDataGenerator>();
        return services;
    }

    public static IServiceCollection AddJsonMockGenerator(this IServiceCollection services)
    {
        services.AddScoped<IProviderMockGenerator, JsonProviderMockDataGenerator>();
        return services;
    }
}
