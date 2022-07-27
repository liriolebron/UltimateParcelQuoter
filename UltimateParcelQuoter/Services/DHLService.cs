using RestSharp;
using UltimateParcelQuoter.DTOs.FedExService;
using UltimateParcelQuoter.Interfaces;

namespace UltimateParcelQuoter.Services
{
    public class DHLService : PostalService<PackageQuoteDTO, PackageQuoteResponseDTO>
    {
        public DHLService(string baseUrl, string bearerToken) : base(baseUrl, bearerToken)
        {
        }

        public override async Task<PackageQuoteResponseDTO> Quote(PackageQuoteDTO entity)
        {
            var request = new RestRequest()
               .AddJsonBody(entity);

            return await ExecuteRequest<PackageQuoteResponseDTO>(request);
        }
    }
}
