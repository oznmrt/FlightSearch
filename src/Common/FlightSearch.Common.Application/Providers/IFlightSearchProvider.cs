
using FlightSearch.Common.Core.Models;

namespace FlightSearch.Common.Application.Providers;

public interface IFlightSearchProvider
{
    Task<List<FlightData>> SearchFlightsAsync(string origin, string destination, DateTime departureDate);
}
