using UltimateParcelQuoter.DTOs.Common;

namespace UltimateParcelQuoter.DTOs.FedExService
{
    public class FedExPackageQuoteDTO
    {
        public string Consignee { get; set; }
        public string Consignor { get; set; }

        public List<PackageDimensions> Cartons { get; set; }
    }
}

