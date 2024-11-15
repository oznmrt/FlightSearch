namespace FlightSearch.Common.Application.Tests;

public class FlightSearchTestFixture : IDisposable
{
    // Common mock data for the tests
    public FlightSearchRequest DefaultFlightSearchRequest { get; private set; }
    public List<IFlightData> MockFlightData { get; private set; }
    public string MockResponse { get; private set; }

    public FlightSearchTestFixture()
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

        MockFlightData = new List<IFlightData>
        {
            new FlightData { FlightNumber = "FL123", Price = 300.0, Currency = "USD" },
            new FlightData { FlightNumber = "FL124", Price = 250.0, Currency = "USD" }
        };

        MockResponse = "Sample Response";
    }

    // Cleanup after each test if needed
    public void Dispose()
    {
        // Dispose resources here if needed
    }
}
