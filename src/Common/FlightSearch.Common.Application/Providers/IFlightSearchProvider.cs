using FlightSearch.Common.Application.DTOs;

namespace FlightSearch.Common.Application.Providers;

public interface IFlightSearchProvider
{
    // Ortak SearchFlights methodu
    Task<List<FlightData>> SearchFlightsAsync(string origin, string destination, DateTime departureDate);
}
