using System.Xml.Serialization;

namespace FlightSearch.Common.Core.Models;

public interface IFlightData
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