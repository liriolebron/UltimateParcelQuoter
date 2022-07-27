using RestSharp;
using UltimateParcelQuoter.DTOs.UPSService;
using UltimateParcelQuoter.Interfaces;

namespace UltimateParcelQuoter.Services
{
    public class UPSService : PostalService<PackageQuoteDTO, PackageQuoteResponseDTO>
    {
        public UPSService(string baseUrl, string bearerToken) : base(baseUrl, bearerToken)
        {
        }

        public override async Task<PackageQuoteResponseDTO> Quote(PackageQuoteDTO entity)
        {
            var request = new RestRequest()
               .AddXmlBody(entity);

            return await ExecuteRequest<PackageQuoteResponseDTO>(request);
        }
    }
}
