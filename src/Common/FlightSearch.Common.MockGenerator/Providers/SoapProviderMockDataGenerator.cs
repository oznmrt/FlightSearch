
using FlightSearch.Common.Core.Constants;
using System.Xml.Linq;

namespace FlightSearch.Common.MockGenerator.Providers;

public class SoapProviderMockDataGenerator : IProviderMockGenerator
{
    public string GenerateMockResponse(string origin, string destination, DateTime departureDate)
    {
        var flightList = FlightMockDataGenerator.GenerateMockFlights(ProviderConstants.HopeAir, origin, destination, departureDate);
        var xDocument = new XDocument(
            new XElement("Flights",
                flightList.Select(flight => new XElement("Flight",
                    new XElement("FlightNumber", flight.FlightNumber),
                    new XElement("Departure", flight.Departure),
                    new XElement("Arrival", flight.Arrival),
                    new XElement("Price", flight.Price),
                    new XElement("Currency", flight.Currency),
                    new XElement("DepartureTime", flight.DepartureTime),
                    new XElement("ArrivalTime", flight.ArrivalTime),
                    new XElement("Duration", flight.Duration),
                    new XElement("ProviderName", flight.ProviderName)
                ))
            )
        );

        return xDocument.ToString();
    }
}
