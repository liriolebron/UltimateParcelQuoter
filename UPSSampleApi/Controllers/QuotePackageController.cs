using Microsoft.AspNetCore.Mvc;
using UPSSampleApi.Models.PackageQuote;

namespace UPSSampleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QuotePackageController : ControllerBase
{
    [HttpPost]
    [Produces("text/xml")]
    [Consumes("text/xml")]
    public IActionResult Quote(PackageQuote? packageQuote)
    {
        return Ok(new PackageQuoteResponse()
        {
            Quote = new Random().Next()
        });
    }
}

