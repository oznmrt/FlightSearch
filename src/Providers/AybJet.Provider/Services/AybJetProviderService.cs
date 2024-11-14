using AybJet.Provider.Models;
using FlightSearch.Common.Application.Providers;
using FlightSearch.Common.Core.Models;
using FlightSearch.Common.MockGenerator;
using Newtonsoft.Json;

namespace AybJet.Provider.Services;

public class AybJetProviderService(IProviderMockGenerator mockGenerator) : FlightSearchProvider
{
    private readonly IProviderMockGenerator _mockGenerator = mockGenerator;

    protected override List<FlightData> ConvertResponseToFlights(string response)
    {
        var flightData = JsonConvert.DeserializeObject<AybJetApiResponse>(response);
        return flightData!.Flights;
    }

    protected override Task<string> GetFlightDataAsync(string origin, string destination, DateTime departureDate)
    {
        return Task.FromResult(_mockGenerator.GenerateMockResponse(origin, destination, departureDate));
    }
}
