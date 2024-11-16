namespace FlightSearch.API.Tests;

public class FlightSearchServiceTestFixture : IDisposable
{
    public FlightSearchService Service { get; set; }
    public Mock<IAybJetHttpClient> MockAybJetHttpClient { get; set; }
    public Mock<IHopeAirHttpClient> MockHopeAirHttpClient { get; set; }
    public FlightSearchRequest DefaultFlightSearchRequest { get; private set; }
    public FlightSearchServiceTestFixture()
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

        MockAybJetHttpClient = new Mock<IAybJetHttpClient>();
        MockHopeAirHttpClient = new Mock<IHopeAirHttpClient>();

        // Initial mock setup
        SetupMockData();

        Service = new FlightSearchService(MockAybJetHttpClient.Object, MockHopeAirHttpClient.Object);
    }

    // Method to set up mock data (used in the constructor and before each test case)
    public void SetupMockData(List<FlightData> mockResponse = null)
    {
        var defaultMockResponse = new List<FlightData>
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
                },
                new FlightData
                {
                    FlightNumber = "AJ234",
                    Departure = "NYC",
                    Arrival = "LAX",
                    Price = 150.0,
                    Currency = "USD",
                    DepartureTime = "2024-12-01T10:00:00",
                    ArrivalTime = "2024-12-01T14:00:00",
                    Duration = "4h",
                    ProviderName = "Dummy"
                }
            };

        mockResponse ??= defaultMockResponse;

        // Mock GenerateMockResponse with the provided or default mock response
        MockAybJetHttpClient
            .Setup(m => m.GetAsync<FlightSearchRequest, IEnumerable<FlightData>>(It.IsAny<string>(), DefaultFlightSearchRequest, default))
            .Returns(Task.FromResult(mockResponse.AsEnumerable()));

        MockHopeAirHttpClient
            .Setup(m => m.GetAsync<FlightSearchRequest, IEnumerable<FlightData>>(It.IsAny<string>(), DefaultFlightSearchRequest, default))
            .Returns(Task.FromResult(mockResponse.AsEnumerable()));
    }

    public void Dispose()
    {
        MockAybJetHttpClient.Reset();
        MockHopeAirHttpClient.Reset();

        Service = new FlightSearchService(MockAybJetHttpClient.Object, MockHopeAirHttpClient.Object);
    }
}