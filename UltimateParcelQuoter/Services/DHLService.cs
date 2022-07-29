using RestSharp;
using System.Text.Json;
using UltimateParcelQuoter.DTOs.DHLService;
using UltimateParcelQuoter.Interfaces;

namespace UltimateParcelQuoter.Services
{
    public class DHLService : PostalService<DHLPackageQuoteDTO, DHLPackageQuoteResponseDTO>
    {
        public DHLService(IConfiguration configuration) :
            base(configuration["DHL:BaseUrl"],
                configuration["DHL:UserName"],
                configuration["DHL:Password"])
        {
        }
        public override async Task<DHLPackageQuoteResponseDTO> Quote(DHLPackageQuoteDTO entity)
        {
            var request = new RestRequest("/QuotePackage", Method.Post)
                .AddJsonBody(entity);

            return await GetAsync(request);
        }
    }
}
