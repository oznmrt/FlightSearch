using System.Xml.Serialization;

namespace FlightSearch.Common.Core.Models;

public class FlightData
{
    [XmlElement("FlightNumber")]
    public string FlightNumber { get; set; }

    [XmlElement("Departure")]
    public string Departure { get; set; }

    [XmlElement("Arrival")]
    public string Arrival { get; set; }

    [XmlElement("Price")]
    public double Price { get; set; }

    [XmlElement("Currency")]
    public string Currency { get; set; }

    [XmlElement("DepartureTime")]
    public string DepartureTime { get; set; }

    [XmlElement("ArrivalTime")]
    public string ArrivalTime { get; set; }

    [XmlElement("Duration")]
    public string Duration { get; set; }

    [XmlElement("ProviderName")]
    public string ProviderName { get; set; }
}
