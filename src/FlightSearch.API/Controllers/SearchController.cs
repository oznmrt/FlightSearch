using FlightSearch.Common.Application.Providers;
using FlightSearch.Common.Core.Models;
using FlightSearch.Common.GenericHttpClient.HttpClients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightSearch.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController(IAybJetHttpClient aybJetHttpClient) : ControllerBase
{
    private readonly IAybJetHttpClient _aybJetHttpClient = aybJetHttpClient;

    [HttpGet]
    public async Task<IActionResult> SearchFlights([FromQuery] FlightSearchRequest request)
    {
        var test = await _aybJetHttpClient.GetAsync<string>("");
        return Ok();
    }
}