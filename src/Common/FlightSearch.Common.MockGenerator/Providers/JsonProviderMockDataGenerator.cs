
using Newtonsoft.Json;

namespace FlightSearch.Common.MockGenerator.Providers;

public class JsonProviderMockDataGenerator : IProviderMockGenerator
{
    public string GenerateMockResponse(string origin, string destination, DateTime departureDate)
    {
        var flightList = FlightMockDataGenerator.GenerateMockFlights(origin, destination, departureDate);
        return JsonConvert.SerializeObject(new { Flights = flightList });
    }
}
