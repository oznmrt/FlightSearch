using FlightSearch.Common.Core.Enums;

namespace FlightSearch.Common.GenericHttpClient.Attributes;

[AttributeUsage(AttributeTargets.Interface)]
public class ProviderAttribute(ProviderType providerType) : Attribute
{
    public ProviderType ProviderType { get; } = providerType;
}