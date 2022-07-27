using UltimateParcelQuoter.DTOs.Common;

namespace UltimateParcelQuoter.DTOs.FedExService
{
    public class PackageQuoteDTO
    {
        public string Consignee { get; set; }
        public string Consignor { get; set; }

        public List<PackageDimensions> Cartons { get; set; }
    }
}

