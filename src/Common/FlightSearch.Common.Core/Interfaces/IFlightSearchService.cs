using FlightSearch.Common.Core.Models;

namespace FlightSearch.Common.Core.Interfaces;

public interface IFlightSearchService
{
    Task<IEnumerable<IFlightData>> SearchFlightsAsync(string origin, string destination, DateTime departureDate);
}