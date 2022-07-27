using UltimateParcelQuoter.DTOs.Common;

namespace UltimateParcelQuoter.DTOs.UPSService
{
    public class PackageQuoteDTO
    {
        public string Source { get; set; }
        public string Destination { get; set; }

        public List<PackageDimensions> Packages { get; set; }
    }
}

