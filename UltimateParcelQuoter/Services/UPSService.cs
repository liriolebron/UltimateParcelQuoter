using RestSharp;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UltimateParcelQuoter.DTOs.UPSService;
using UltimateParcelQuoter.Interfaces;

namespace UltimateParcelQuoter.Services
{
    public class UPSService : PostalService<UPSPackageQuoteDTO, UPSPackageQuoteResponseDTO>
    {
        public UPSService(IConfiguration configuration) :
            base(configuration["UPS:BaseUrl"],
                configuration["UPS:ApiToken"])
        {
        }

        public override async Task<UPSPackageQuoteResponseDTO> Quote(UPSPackageQuoteDTO entity)
        {
            var request = new RestRequest("/QuotePackage", Method.Post)
            {
                RequestFormat = DataFormat.Xml
            };

            var serializedObject = string.Empty;
            var serializer = new XmlSerializer(entity.GetType());
            using (var memStm = new MemoryStream())
            using (var xw = XmlWriter.Create(memStm))
            {
                serializer.Serialize(xw, entity);
                var utf8String = memStm.ToArray();
                serializedObject = Encoding.Default.GetString(utf8String);
            }

            request.AddParameter("text/xml", serializedObject, ParameterType.RequestBody);

            return await GetAsync(request);
        }
    }
}
