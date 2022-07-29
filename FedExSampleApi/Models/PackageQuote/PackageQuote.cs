using UltimateParcelQuoter.DTOs.Common;

namespace FedExSampleApi.Models.PackageQuote
{
    public class PackageQuote
    {
        public string? Consignee { get; set; }
        public string? Consignor { get; set; }

        public List<PackageDimensions>? Cartons { get; set; }
    }
}

