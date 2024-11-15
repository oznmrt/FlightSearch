using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace FlightSearch.Common.Core.Models;

public class FlightData : IFlightData
{
    [JsonProperty("flightNumber")]
    public string FlightNumber { get; set; }

    [JsonProperty("departure")]
    public string Departure { get; set; }

    [JsonProperty("arrival")]
    public string Arrival { get; set; }

    [JsonProperty("price")]
    public double Price { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("departureTime")]
    public string DepartureTime { get; set; }

    [JsonProperty("arrivalTime")]
    public string ArrivalTime { get; set; }

    [JsonProperty("duration")]
    public string Duration { get; set; }

    [JsonProperty("providerName")]
    public string ProviderName { get; set; }
}

public class FlightDataXML : IFlightData
{
    [XmlElement("flightNumber")]
    public string FlightNumber { get; set; }

    [XmlElement("departure")]
    public string Departure { get; set; }

    [XmlElement("arrival")]
    public string Arrival { get; set; }

    [XmlElement("price")]
    public double Price { get; set; }

    [XmlElement("currency")]
    public string Currency { get; set; }

    [XmlElement("departureTime")]
    public string DepartureTime { get; set; }

    [XmlElement("arrivalTime")]
    public string ArrivalTime { get; set; }

    [XmlElement("duration")]
    public string Duration { get; set; }

    [XmlElement("providerName")]
    public string ProviderName { get; set; }
}