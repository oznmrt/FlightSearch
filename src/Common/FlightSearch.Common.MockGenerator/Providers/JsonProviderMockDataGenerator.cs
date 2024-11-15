using FlightSearch.Common.Core.Constants;
using FlightSearch.Common.Core.Enums;
using Newtonsoft.Json;

namespace FlightSearch.Common.MockGenerator.Providers;

public class JsonProviderMockDataGenerator : IProviderMockGenerator
{
    public string GenerateMockResponse(string origin, string destination, DateTime departureDate, DateTime returnDate, int passengerCount)
    {
        var flightList = FlightMockDataGenerator.GenerateMockFlights(ProviderConstants.AybJet, origin, destination, departureDate, returnDate, passengerCount);
        return JsonConvert.SerializeObject(new { Flights = flightList });
    }
}