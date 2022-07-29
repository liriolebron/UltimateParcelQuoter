using UltimateParcelQuoter.DTOs.Common;

namespace UltimateParcelQuoter.DTOs.DHLService
{
    public class DHLPackageQuoteDTO
    {
        public string ContactAdress { get; set; }
        public string WarehouseAddress { get; set; }

        public List<PackageDimensions> PackageDimensions { get; set; }
    }
}

