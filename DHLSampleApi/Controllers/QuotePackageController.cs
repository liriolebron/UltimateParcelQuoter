using DHLSampleApi.Models.PackageQuote;
using Microsoft.AspNetCore.Mvc;

namespace DHLSampleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QuotePackageController : ControllerBase
{
    [HttpPost]
    public IActionResult Quote(PackageQuote? packageQuote)
    {  
        return Ok(new PackageQuoteResponse()
        {
            Total = new Random().Next()
        });
    }       
}

