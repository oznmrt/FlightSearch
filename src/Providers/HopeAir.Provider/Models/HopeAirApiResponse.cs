using FlightSearch.Common.Core.Models;
using System.Xml.Serialization;

namespace HopeAir.Provider.Models;

[XmlRoot("Flights", Namespace = "")]
public class HopeAirApiResponse
{
    [XmlElement("Flight")]
    public List<FlightData> Flights { get; set; } = new();
}