using FlightSearch.Common.Core.Enums;
using FlightSearch.Common.GenericHttpClient.HttpClients.Interfaces;

namespace FlightSearch.Common.GenericHttpClient.HttpClients;

public class HopeAirHttpClient(IServiceProvider provider) : BaseHttpClient(provider), IHopeAirHttpClient
{
    public override ProviderType ProviderType => ProviderType.HopeAir;
}