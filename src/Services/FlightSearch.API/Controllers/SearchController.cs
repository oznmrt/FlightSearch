using FlightSearch.Common.Application.Providers;
using FlightSearch.Common.Core.Interfaces;
using FlightSearch.Common.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightSearch.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController(IFlightSearchService flightSearchService) : ControllerBase
{
    private readonly IFlightSearchService _flightSearchService = flightSearchService;

    [HttpGet]
    public async Task<IActionResult> SearchFlights([FromQuery] FlightSearchRequest request)
    {
        return Ok(await _flightSearchService.SearchFlightsAsync(request));
    }
}