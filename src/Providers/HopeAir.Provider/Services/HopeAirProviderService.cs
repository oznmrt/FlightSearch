using FlightSearch.Common.Application.Providers;
using FlightSearch.Common.Core.Models;
using FlightSearch.Common.MockGenerator;
using FlightSearch.Common.Utilities.Extensions;
using HopeAir.Provider.Models;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HopeAir.Provider.Services;

public class HopeAirProviderService(IProviderMockGenerator mockGenerator) : FlightSearchProvider
{
    private readonly IProviderMockGenerator _mockGenerator = mockGenerator;

    protected override IEnumerable<IFlightData> ConvertResponseToFlights(string response)
    {
        var flightData = response.ConvertSoapXML<GetFlightInfoResponse>();
        return flightData!.Flights.FlightList;
    }

    protected override Task<string> GetFlightDataAsync(string origin, string destination, DateTime departureDate)
    {
        // API call for SOAP service
        return Task.FromResult(_mockGenerator.GenerateMockResponse(origin, destination, departureDate));
    }
}