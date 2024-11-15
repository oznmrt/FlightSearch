using FlightSearch.Common.Core.Models;

namespace FlightSearch.Common.Application.Providers;

public interface IFlightSearchProvider
{
    Task<IEnumerable<IFlightData>> SearchFlightsAsync(string origin, string destination, DateTime departureDate);
}