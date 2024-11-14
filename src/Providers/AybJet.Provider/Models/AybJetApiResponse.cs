using FlightSearch.Common.Application.DTOs;

namespace AybJet.Provider.Models;

public class AybJetApiResponse
{
    public List<FlightData> Flights { get; set; } = null!;
}
