using FlightSearch.Common.Application.Providers;
using FlightSearch.Common.Core.Models;
using FlightSearch.Common.MockGenerator;
using HopeAir.Provider.Models;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;

namespace HopeAir.Provider.Services;

public class HopeAirProviderService(IProviderMockGenerator mockGenerator) : FlightSearchProvider
{
    private readonly IProviderMockGenerator _mockGenerator = mockGenerator;

    protected override List<FlightData> ConvertResponseToFlights(string response)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(HopeAirApiResponse));

        using (StringReader reader = new StringReader(response))
        {
            var flightData = (HopeAirApiResponse)serializer.Deserialize(reader)!;
            return flightData!.Flights;
        }
    }

    protected override Task<string> GetFlightDataAsync(string origin, string destination, DateTime departureDate)
    {
        return Task.FromResult(_mockGenerator.GenerateMockResponse(origin, destination, departureDate));
    }
}
