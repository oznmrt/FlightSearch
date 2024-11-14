namespace FlightSearch.Common.Application.DTOs;

public class FlightData
{
    public string FlightNumber { get; set; }
    public string Departure { get; set; }
    public string Arrival { get; set; }
    public double Price { get; set; }
    public string Currency { get; set; }
    public string DepartureTime { get; set; }
    public string ArrivalTime { get; set; }
    public string Duration { get; set; }
    public string ProviderName { get; set; }
}
