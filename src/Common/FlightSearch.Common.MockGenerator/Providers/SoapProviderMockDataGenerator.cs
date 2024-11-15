using FlightSearch.Common.Core.Constants;
using System.Xml.Linq;

namespace FlightSearch.Common.MockGenerator.Providers;

public class SoapProviderMockDataGenerator : IProviderMockGenerator
{
    public string GenerateMockResponse(string origin, string destination, DateTime departureDate)
    {
        var flightList = FlightMockDataGenerator.GenerateMockFlights(ProviderConstants.HopeAir, origin, destination, departureDate);

        // Define the namespaces
        XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
        XNamespace sky = "http://skyblue.com/flight";

        // Generate the XML structure
        XElement xDocument = new XElement(soapenv + "Envelope",
            new XAttribute(XNamespace.Xmlns + "soapenv", soapenv),
            new XAttribute(XNamespace.Xmlns + "sky", sky),
            new XElement(soapenv + "Body",
                new XElement(sky + "GetFlightInfoResponse",
                    new XElement(sky + "flights",
                        flightList.Select(f => new XElement(sky + "flight",
                            new XElement(sky + "flightNumber", f.FlightNumber),
                            new XElement(sky + "departure", f.Departure),
                            new XElement(sky + "arrival", f.Arrival),
                            new XElement(sky + "price", f.Price),
                            new XElement(sky + "currency", f.Currency),
                            new XElement(sky + "duration", f.Duration),
                            new XElement(sky + "departureTime", f.DepartureTime),
                            new XElement(sky + "arrivalTime", f.ArrivalTime),
                            new XElement(sky + "providerName", f.ProviderName)
                        ))
                    )
                )
            )
        );

        return xDocument.ToString();
    }
}