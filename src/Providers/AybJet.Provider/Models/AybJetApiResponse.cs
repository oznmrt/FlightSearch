using FlightSearch.Common.Core.Models;

namespace AybJet.Provider.Models;

public class AybJetApiResponse
{
    public List<FlightData> Flights { get; set; } = null!;
}
