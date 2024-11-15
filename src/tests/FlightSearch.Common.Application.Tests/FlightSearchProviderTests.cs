namespace FlightSearch.Common.Application.Tests;

public class FlightSearchProviderTests : IClassFixture<FlightSearchTestFixture>
{
    private readonly FlightSearchTestFixture _fixture;

    public FlightSearchProviderTests(FlightSearchTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task SearchFlightsAsync_ShouldReturnConvertedFlightData()
    {
        // Arrange
        var provider = new TestFlightSearchProvider(_fixture.MockResponse, _fixture.MockFlightData);

        // Act
        var flights = await provider.SearchFlightsAsync(_fixture.DefaultFlightSearchRequest);

        // Assert
        Assert.NotNull(flights);
    }

    [Fact]
    public async Task SearchFlightsAsync_ShouldThrowNullReferenceException_WhenRequestIsNull()
    {
        // Arrange
        var provider = new TestFlightSearchProvider(_fixture.MockResponse, _fixture.MockFlightData);

        // Act & Assert
        await Assert.ThrowsAsync<NullReferenceException>(() => provider.SearchFlightsAsync(null));
    }

    [Fact]
    public async Task SearchFlightsAsync_ShouldReturnEmptyList_WhenNoData()
    {
        // Arrange
        var provider = new TestFlightSearchProvider(_fixture.MockResponse, new List<IFlightData>());

        // Act
        var flights = await provider.SearchFlightsAsync(_fixture.DefaultFlightSearchRequest);

        // Assert
        Assert.False(flights.Any());
    }
}