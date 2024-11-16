using FlightSearch.Common.Core.Models.HopeAir;
using System.Xml.Linq;

namespace HopeAir.Provider.Tests;

public class HopeAirProviderServiceTestFixture : IDisposable
{
    public HopeAirProviderService Service { get; private set; }
    public Mock<IProviderMockGenerator> MockGenerator { get; private set; }
    public FlightSearchRequest DefaultFlightSearchRequest { get; private set; }
    public HopeAirProviderServiceTestFixture()
    {
        // Initialize common mock data
        DefaultFlightSearchRequest = new FlightSearchRequest
        {
            Origin = "NYC",
            Destination = "LAX",
            DepartureDate = DateTime.Now,
            ReturnDate = DateTime.Now.AddDays(5),
            PassengerCount = 1
        };

        MockGenerator = new Mock<IProviderMockGenerator>();

        var flightList = new List<FlightData>
        {
            new FlightData
            {
                FlightNumber = "AJ123",
                Departure = "NYC",
                Arrival = "LAX",
                Price = 350.0,
                Currency = "USD",
                DepartureTime = "2024-12-01T10:00:00",
                ArrivalTime = "2024-12-01T14:00:00",
                Duration = "4h",
                ProviderName = "Dummy"
            }
        };

        // Define the namespaces
        XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
        XNamespace sky = "http://skyblue.com/flight";

        // Generate the XML structure
        XElement xDocument = new(soapenv + "Envelope",
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

        // Mock GenerateMockResponse
        MockGenerator
            .Setup(m => m.GenerateMockResponse(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<int>()))
            .Returns(xDocument.ToString());

        Service = new HopeAirProviderService(MockGenerator.Object);
    }

    public void Dispose()
    {
    }
}