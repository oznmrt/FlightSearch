using FlightSearch.Common.Application.Providers;
using FlightSearch.Common.Core.Models;
using FlightSearch.Common.Core.Models.AybJet;
using FlightSearch.Common.MockGenerator;
using Newtonsoft.Json;

namespace FlightSearch.Common.Application.Services;

public class AybJetProviderService(IProviderMockGenerator mockGenerator) : BaseProviderService
{
    private readonly IProviderMockGenerator _mockGenerator = mockGenerator;

    protected override List<FlightData> ConvertResponseToFlights(string response)
    {
        var flightData = JsonConvert.DeserializeObject<AybJetApiResponse>(response);
        return flightData!.Flights;
    }

    protected override Task<string> GetFlightDataAsync(string origin, string destination, DateTime departureDate, DateTime returnDate, int passengerCount)
    {
        // API call for REST service
        return Task.FromResult(_mockGenerator.GenerateMockResponse(origin, destination, departureDate, returnDate, passengerCount));
    }
}