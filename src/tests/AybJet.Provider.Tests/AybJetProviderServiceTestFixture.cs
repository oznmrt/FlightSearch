namespace AybJet.Provider.Tests;

public class AybJetProviderServiceTestFixture : IDisposable
{
    public AybJetProviderService Service { get; private set; }
    public Mock<IProviderMockGenerator> MockGenerator { get; private set; }
    public FlightSearchRequest DefaultFlightSearchRequest { get; private set; }
    public AybJetProviderServiceTestFixture()
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

        var mockResponse = new AybJetApiResponse
        {
            Flights = new List<FlightData>
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
            }
        };
        // Mock GenerateMockResponse
        MockGenerator
            .Setup(m => m.GenerateMockResponse(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<int>()))
            .Returns(JsonConvert.SerializeObject(mockResponse));

        Service = new AybJetProviderService(MockGenerator.Object);
    }

    public void Dispose()
    {
    }
}