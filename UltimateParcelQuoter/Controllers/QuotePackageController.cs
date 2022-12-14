using Microsoft.AspNetCore.Mvc;
using UltimateParcelQuoter.Interfaces;
using UltimateParcelQuoter.Models;

namespace UltimateParcelQuoter.Controllers;

[ApiController]
[Route("[controller]")]
public class QuotePackageController : ControllerBase
{
    private readonly IParcelQuoter _parcelQuoter;

    public QuotePackageController(IParcelQuoter parcelQuoter)
    {
        _parcelQuoter = parcelQuoter;
    }

    [HttpPost]
    public async Task<IActionResult> Quote(PackageQuote quote)
    {
        if (quote == null || quote?.Packages == null || quote?.Packages?.Count == 0)
            return BadRequest();

        return Ok(await _parcelQuoter.Quote(quote));
    }
}

