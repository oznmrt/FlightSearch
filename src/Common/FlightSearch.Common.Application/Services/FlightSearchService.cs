using FlightSearch.Common.Core.Interfaces;
using FlightSearch.Common.Core.Models;
using FlightSearch.Common.GenericHttpClient.HttpClients.Interfaces;
using FlightSearch.Common.Utilities.Extensions;

namespace FlightSearch.Common.Application.Services;

public class FlightSearchService(IAybJetHttpClient aybJetHttpClient, IHopeAirHttpClient hopeAirHttpClient) : IFlightSearchService
{
    private readonly IAybJetHttpClient _aybJetHttpClient = aybJetHttpClient;
    private readonly IHopeAirHttpClient _hopeAirHttpClient = hopeAirHttpClient;

    public async Task<IEnumerable<IFlightData>> SearchFlightsAsync(FlightSearchRequest request, CancellationToken cancellationToken = default)
    {
        var tasks = new List<Task<IEnumerable<FlightData>>>
        {
            // SafeApiCall is used to handle any issues during the API call, returning null data in case of failure.
            _aybJetHttpClient.GetAsync<FlightSearchRequest, IEnumerable<FlightData>>("Search", request, cancellationToken).SafeApiCall(),
            _hopeAirHttpClient.GetAsync<FlightSearchRequest, IEnumerable<FlightData>>("Search", request, cancellationToken).SafeApiCall()
        };

        var results = await Task.WhenAll(tasks);
        // Flatten and order by Price
        return results
            .Where(r => r != null)
            .SelectMany(r => r)
            .OrderBy(f => f.Price)
            .ToList();
    }
}