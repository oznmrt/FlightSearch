namespace FlightSearch.API.Tests;

public class FlightSearchServiceTests : IClassFixture<FlightSearchServiceTestFixture>
{
    private readonly FlightSearchServiceTestFixture _fixture;

    public FlightSearchServiceTests(FlightSearchServiceTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task SearchFlightsAsync_ShouldReturnFlightData()
    {
        // Arrange
        _fixture.SetupMockData();

        // Act
        var flights = await _fixture.Service.SearchFlightsAsync(_fixture.DefaultFlightSearchRequest, default);

        // Assert
        flights.Should().NotBeNull();
        flights.Should().NotBeEmpty();
    }

    [Fact]
    public async Task SearchFlightsAsync_ShouldReturnEmptyList_WhenRequestIsNull()
    {
        // Arrange
        _fixture.SetupMockData();

        _fixture.MockHopeAirHttpClient
            .Setup(m => m.GetAsync<FlightSearchRequest, IEnumerable<FlightData>>(It.IsAny<string>(), null, default))
            .Returns(Task.FromResult<IEnumerable<FlightData>>(null));

        _fixture.MockAybJetHttpClient
            .Setup(m => m.GetAsync<FlightSearchRequest, IEnumerable<FlightData>>(It.IsAny<string>(), null, default))
            .Returns(Task.FromResult<IEnumerable<FlightData>>(null));

        _fixture.Service = new FlightSearchService(_fixture.MockAybJetHttpClient.Object, _fixture.MockHopeAirHttpClient.Object);

        // Act
        var flights = await _fixture.Service.SearchFlightsAsync(null);

        // Assert
        flights.Should().NotBeNull();
        flights.Should().BeEmpty();
    }

    [Fact]
    public async Task SearchFlightsAsync_ShouldReturnEmptyList_WhenNoData()
    {
        // Arrange
        _fixture.SetupMockData();
        _fixture.MockHopeAirHttpClient
            .Setup(m => m.GetAsync<FlightSearchRequest, IEnumerable<FlightData>>(It.IsAny<string>(), _fixture.DefaultFlightSearchRequest, default))
            .Returns(Task.FromResult<IEnumerable<FlightData>>(null));

        _fixture.MockAybJetHttpClient
            .Setup(m => m.GetAsync<FlightSearchRequest, IEnumerable<FlightData>>(It.IsAny<string>(), _fixture.DefaultFlightSearchRequest, default))
            .Returns(Task.FromResult<IEnumerable<FlightData>>(null));

        _fixture.Service = new FlightSearchService(_fixture.MockAybJetHttpClient.Object, _fixture.MockHopeAirHttpClient.Object);

        // Act
        var flights = await _fixture.Service.SearchFlightsAsync(_fixture.DefaultFlightSearchRequest);

        // Assert
        flights.Should().NotBeNull();
        flights.Should().BeEmpty();
    }

    [Fact]
    public async Task SearchFlightsAsync_ShouldReturnFlightsOrderedByPrice()
    {
        // Arrange
        _fixture.SetupMockData();

        // Act
        var flights = await _fixture.Service.SearchFlightsAsync(_fixture.DefaultFlightSearchRequest);

        // Assert
        flights.First().Price.Should().Be(150);
        flights.Last().Price.Should().Be(350);
    }

    [Fact]
    public async Task SearchFlightsAsync_ShouldReturnEmptyList_WhenHopeAirClientThrowTimeoutException()
    {
        // Arrange
        _fixture.SetupMockData();
        _fixture.MockHopeAirHttpClient
            .Setup(m => m.GetAsync<FlightSearchRequest, IEnumerable<FlightData>>(It.IsAny<string>(), _fixture.DefaultFlightSearchRequest, default))
            .Returns(async () =>
            {
                await Task.Delay(1000); // Simulate delay before timeout
                throw new TaskCanceledException("Request timed out.");
            });

        _fixture.Service = new FlightSearchService(_fixture.MockAybJetHttpClient.Object, _fixture.MockHopeAirHttpClient.Object);

        // Act
        var flights = await _fixture.Service.SearchFlightsAsync(_fixture.DefaultFlightSearchRequest);

        // Assert
        flights.Should().HaveCount(2);
    }

    [Fact]
    public async Task SearchFlightsAsync_ShouldReturnEmptyList_WhenAybJetClientThrowTimeoutException()
    {
        // Arrange
        _fixture.SetupMockData();
        _fixture.MockAybJetHttpClient
            .Setup(m => m.GetAsync<FlightSearchRequest, IEnumerable<FlightData>>(It.IsAny<string>(), _fixture.DefaultFlightSearchRequest, default))
            .Returns(async () =>
            {
                await Task.Delay(1000); // Simulate delay before timeout
                throw new TaskCanceledException("Request timed out.");
            });

        _fixture.Service = new FlightSearchService(_fixture.MockAybJetHttpClient.Object, _fixture.MockHopeAirHttpClient.Object);


        // Act
        var flights = await _fixture.Service.SearchFlightsAsync(_fixture.DefaultFlightSearchRequest);

        // Assert
        flights.Should().HaveCount(2);
    }
}