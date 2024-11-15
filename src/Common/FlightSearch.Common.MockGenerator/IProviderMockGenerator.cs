namespace FlightSearch.Common.MockGenerator;

public interface IProviderMockGenerator
{
    string GenerateMockResponse(string origin, string destination, DateTime departureDate, DateTime returnDate, int passengerCount);
}