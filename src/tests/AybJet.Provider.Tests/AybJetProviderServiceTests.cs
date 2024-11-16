namespace AybJet.Provider.Tests;

public class AybJetProviderServiceTests: IClassFixture<AybJetProviderServiceTestFixture>
{
    private readonly AybJetProviderServiceTestFixture _fixture;

    public AybJetProviderServiceTests(AybJetProviderServiceTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task SearchFlightsAsync_ShouldReturnConvertedFlightData()
    {
        // Arrange & Act
        var flights = await _fixture.Service.SearchFlightsAsync(_fixture.DefaultFlightSearchRequest);

        // Assert
        Assert.NotNull(flights);
    }

    [Fact]
    public async Task SearchFlightsAsync_ShouldThrowNullReferenceException_WhenRequestIsNull()
    {
        // Act & Assert
        await Assert.ThrowsAsync<NullReferenceException>(() => _fixture.Service.SearchFlightsAsync(null));
    }
}