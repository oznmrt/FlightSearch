using FlightSearch.Common.Core.Enums;
using FlightSearch.Common.GenericHttpClient.HttpClients.Interfaces;

namespace FlightSearch.Common.GenericHttpClient.HttpClients;

public class AybJetHttpClient(IServiceProvider provider) : BaseHttpClient(provider), IAybJetHttpClient
{
    public override ProviderType ProviderType => ProviderType.AybJet;
}