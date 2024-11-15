using FlightSearch.Common.Application.Providers;
using FlightSearch.Common.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace HopeAir.Provider.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController(IFlightSearchProvider _flightSearchProvider) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> SearchFlights([FromQuery] FlightSearchRequest request)
    {
        return Ok(await _flightSearchProvider.SearchFlightsAsync(request.Origin, request.Destination, request.DepartureDate));
    }
}