using FlightSearch.Common.Core.Interfaces;
using FlightSearch.Common.Core.Models;
using FlightSearch.Common.GenericHttpClient.HttpClients.Interfaces;

namespace FlightSearch.API.Services;

public class FlightSearchService(IAybJetHttpClient aybJetHttpClient, IHopeAirHttpClient hopeAirHttpClient) : IFlightSearchService
{
    private readonly IAybJetHttpClient _aybJetHttpClient = aybJetHttpClient;
    private readonly IHopeAirHttpClient _hopeAirHttpClient = hopeAirHttpClient;

    public async Task<IEnumerable<IFlightData>> SearchFlightsAsync(FlightSearchRequest request, CancellationToken cancellationToken = default)
    {
        var tasks = new List<Task<IEnumerable<FlightData>>>
        {
            _aybJetHttpClient.GetAsync<FlightSearchRequest, IEnumerable<FlightData>>("Search", request, cancellationToken),
            _hopeAirHttpClient.GetAsync<FlightSearchRequest, IEnumerable<FlightData>>("Search", request, cancellationToken)
        };

        var results = await Task.WhenAll(tasks);
        // Flatten and order by Price
        return results
            .Where(r => r != null)                       // Ensure no null results
            .SelectMany(r => r)                          // Flatten IEnumerable<IEnumerable<FlightData>> to IEnumerable<FlightData>
            .OrderBy(f => f.Price)                       // Order by Price
            .ToList();                                   // Convert to a List
    }
}