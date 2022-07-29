using UltimateParcelQuoter.DTOs.Common;
using UltimateParcelQuoter.DTOs.DHLService;
using UltimateParcelQuoter.DTOs.FedExService;
using UltimateParcelQuoter.DTOs.UPSService;
using UltimateParcelQuoter.Interfaces;
using UltimateParcelQuoter.Models;

namespace UltimateParcelQuoter.Services
{
    public class ParcelQuoter : IParcelQuoter
    {
        private readonly IPostalService<DHLPackageQuoteDTO, DHLPackageQuoteResponseDTO> _dhlService;
        private readonly IPostalService<FedExPackageQuoteDTO, FedExPackageQuoteResponseDTO> _fedexService;
        private readonly IPostalService<UPSPackageQuoteDTO, UPSPackageQuoteResponseDTO> _upsService;

        public ParcelQuoter(IPostalService<DHLPackageQuoteDTO, DHLPackageQuoteResponseDTO> dHLService,
            IPostalService<FedExPackageQuoteDTO, FedExPackageQuoteResponseDTO> fedexService,
            IPostalService<UPSPackageQuoteDTO, UPSPackageQuoteResponseDTO> upsService)
        {
            _dhlService = dHLService;
            _fedexService = fedexService;
            _upsService = upsService;
        }

        public async Task<string> Quote(PackageQuote packageQuote)
        {
            var packageDimensions = packageQuote.Packages
                .Select(p => new PackageDimensions
                {
                    Height = p.Height,
                    Width = p.Width,
                    Length = p.Length,
                    Weight = p.Weight
                }).ToList();

            var dhlQuoteTask = _dhlService.Quote(new()
            {
                ContactAdress = packageQuote.SourceAddress,
                WarehouseAddress = packageQuote.DestinationAddress,
                PackageDimensions = packageDimensions
            });

            var fedexQuoteTask = _fedexService.Quote(new() 
            {
                Consignee = packageQuote.SourceAddress,
                Consignor = packageQuote.DestinationAddress,
                Cartons = packageDimensions
            });

            var upsQuoteTask = _upsService.Quote(new() 
            {
                Source = packageQuote.SourceAddress,
                Destination = packageQuote.DestinationAddress,
                Packages = packageDimensions
            });

            await Task.WhenAll(dhlQuoteTask, fedexQuoteTask, upsQuoteTask);

            var dhlResponse = await dhlQuoteTask;
            var fedexResponse = await fedexQuoteTask;
            var upsResponse = await upsQuoteTask;

            var responseValues = new List<QuoteResponse>
            {
                new()
                {
                    PostalService = "DHL",
                    QuotedAmount = dhlResponse.Total
                },

                new()
                {
                    PostalService = "FedEx",
                    QuotedAmount = fedexResponse.Amount
                },

                new()
                {
                    PostalService = "UPS",
                    QuotedAmount = upsResponse.Quote
                }
            };

            var minimumQuoted = responseValues.OrderBy(q => q.QuotedAmount).FirstOrDefault();

            return $"Best price offered by {minimumQuoted?.PostalService}, Quoted amount: {minimumQuoted?.QuotedAmount:C2}";
        }
    }
}
