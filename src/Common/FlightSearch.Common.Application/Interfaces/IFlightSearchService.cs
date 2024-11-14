using FlightSearch.Common.Core.Models;

namespace FlightSearch.Common.Application.Interfaces;

public interface IFlightSearchService
{
    /// <summary>
    /// Flights search query to fetch data from multiple providers (HopeAir, AybJet).
    /// </summary>
    /// <param name="origin">Departure city code (e.g., IST)</param>
    /// <param name="destination">Destination city code (e.g., LHR)</param>
    /// <param name="departureDate">Departure date</param>
    /// <returns>A Task with the aggregated flight search results sorted by price</returns>
    Task<List<FlightData>> SearchFlightsAsync(string origin, string destination, DateTime departureDate);
}
