using FlightSearch.Common.Application.DTOs;
using FlightSearch.Common.Application.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AybJet.Provider.Controllers
{
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
}
