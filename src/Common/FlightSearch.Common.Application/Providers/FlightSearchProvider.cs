using FlightSearch.Common.Core.Models;

namespace FlightSearch.Common.Application.Providers;

public abstract class FlightSearchProvider : IFlightSearchProvider
{
    public async Task<IEnumerable<IFlightData>> SearchFlightsAsync(string origin, string destination, DateTime departureDate)
    {
        var response = await GetFlightDataAsync(origin, destination, departureDate);
        var flights = ConvertResponseToFlights(response);
        return flights;
    }

    protected abstract Task<string> GetFlightDataAsync(string origin, string destination, DateTime departureDate);

    protected abstract IEnumerable<IFlightData> ConvertResponseToFlights(string response);
}