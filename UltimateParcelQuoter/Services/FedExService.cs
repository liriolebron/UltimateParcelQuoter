using RestSharp;
using UltimateParcelQuoter.DTOs.FedExService;
using UltimateParcelQuoter.Interfaces;

namespace UltimateParcelQuoter.Services
{
    public class FedExService : PostalService<FedExPackageQuoteDTO, FedExPackageQuoteResponseDTO>
    {
        public FedExService(IConfiguration configuration) :
            base(configuration["FedEx:BaseUrl"],
                configuration["FedEx:ApiToken"])
        {
        }

        public override async Task<FedExPackageQuoteResponseDTO> Quote(FedExPackageQuoteDTO entity)
        {
            var request = new RestRequest("/QuotePackage", Method.Post)
               .AddJsonBody(entity);

            return await GetAsync(request);
        }
    }
}
