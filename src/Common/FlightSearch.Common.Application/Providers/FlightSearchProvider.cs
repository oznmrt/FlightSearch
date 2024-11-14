using FlightSearch.Common.Application.DTOs;

namespace FlightSearch.Common.Application.Providers;

public abstract class FlightSearchProvider: IFlightSearchProvider
{
    // Ortak SearchFlights methodu
    public async Task<List<FlightData>> SearchFlightsAsync(string origin, string destination, DateTime departureDate)
    {
        var response = await GetFlightDataAsync(origin, destination, departureDate);
        var flights = ConvertResponseToFlights(response);
        return flights;
    }

    // Abstract metotlar: Her provider kendi metodu ile implemente eder.
    protected abstract Task<string> GetFlightDataAsync(string origin, string destination, DateTime departureDate);
    protected abstract List<FlightData> ConvertResponseToFlights(string response);
}
