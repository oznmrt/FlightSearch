namespace FlightSearch.Common.Application.Tests;

public class TestBaseProviderService : BaseProviderService
{
    private readonly string _mockResponse;
    private readonly IEnumerable<IFlightData> _mockFlights;

    public TestBaseProviderService(string mockResponse, IEnumerable<IFlightData> mockFlights)
    {
        _mockResponse = mockResponse;
        _mockFlights = mockFlights;
    }

    protected override async Task<string> GetFlightDataAsync(string origin, string destination, DateTime departureDate, DateTime returnDate, int passengerCount)
    {
        return await Task.FromResult(_mockResponse);
    }

    protected override IEnumerable<IFlightData> ConvertResponseToFlights(string response)
    {
        return _mockFlights;
    }
}