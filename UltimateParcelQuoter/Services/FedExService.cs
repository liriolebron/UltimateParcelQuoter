using RestSharp;
using UltimateParcelQuoter.DTOs.FedExService;
using UltimateParcelQuoter.Interfaces;

namespace UltimateParcelQuoter.Services
{
    public class FedExService : PostalService<PackageQuoteDTO, PackageQuoteResponseDTO>
    {
        public FedExService(string baseUrl, string bearerToken) : base(baseUrl, bearerToken)
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
