using FlightSearch.Common.Core.Models;

namespace FlightSearch.Common.Core.Interfaces;

public interface IFlightSearchService
{
    Task<IEnumerable<IFlightData>> SearchFlightsAsync(FlightSearchRequest request, CancellationToken cancellationToken = default);
}