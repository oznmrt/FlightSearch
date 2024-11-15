using FlightSearch.Common.Core.Interfaces;
using FlightSearch.Common.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AybJet.Provider.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController(IFlightSearchService _flightSearchProvider) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> SearchFlights([FromQuery] FlightSearchRequest request)
    {
        return Ok(await _flightSearchProvider.SearchFlightsAsync(request.Origin, request.Destination, request.DepartureDate));
    }
}