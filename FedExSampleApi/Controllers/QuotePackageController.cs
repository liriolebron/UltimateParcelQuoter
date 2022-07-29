using FedExSampleApi.Models.PackageQuote;
using Microsoft.AspNetCore.Mvc;

namespace FedExSampleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QuotePackageController : ControllerBase
{
    [HttpPost]
    public IActionResult Quote(PackageQuote? packageQuote)
    {
        return Ok(new PackageQuoteResponse() 
        {
            Amount = new Random().Next()
        });
    }
}

