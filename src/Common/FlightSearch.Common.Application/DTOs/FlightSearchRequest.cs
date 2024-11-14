namespace FlightSearch.Common.Application.DTOs;

public class FlightSearchRequest
{
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureDate { get; set; }
}
