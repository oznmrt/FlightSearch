using FlightSearch.Common.Core.Models;
using System.Xml.Serialization;

namespace HopeAir.Provider.Models;

[XmlRoot("GetFlightInfoResponse", Namespace = "http://skyblue.com/flight")]
public class GetFlightInfoResponse
{
    [XmlElement("flights", Namespace = "http://skyblue.com/flight")]
    public Flights Flights { get; set; }
}

public class Flights
{
    [XmlElement("flight", Namespace = "http://skyblue.com/flight")]
    public List<FlightDataXML> FlightList { get; set; }
}