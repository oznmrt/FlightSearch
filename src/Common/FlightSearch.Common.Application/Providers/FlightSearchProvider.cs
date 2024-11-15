using FlightSearch.Common.Core.Interfaces;
using FlightSearch.Common.Core.Models;

namespace FlightSearch.Common.Application.Providers;

public abstract class FlightSearchProvider : IFlightSearchService
{
    public async Task<IEnumerable<IFlightData>> SearchFlightsAsync(FlightSearchRequest request, CancellationToken cancellationToken = default)
    {
        var response = await GetFlightDataAsync(request.Origin, request.Destination, request.DepartureDate, request.ReturnDate, request.PassengerCount);
        var flights = ConvertResponseToFlights(response);
        return flights;
    }

    protected abstract Task<string> GetFlightDataAsync(string origin, string destination, DateTime departureDate, DateTime returnDate, int passengerCount);

    protected abstract IEnumerable<IFlightData> ConvertResponseToFlights(string response);
}