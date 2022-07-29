using UPSSampleApi.Models.Common;

namespace UPSSampleApi.Models.PackageQuote
{
    public class PackageQuote
    {
        public string? Source { get; set; }
        public string? Destination { get; set; }

        public List<PackageDimensions>? Packages { get; set; }
    }
}

