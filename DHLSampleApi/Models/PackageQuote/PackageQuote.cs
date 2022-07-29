using DHLSampleApi.Models.Common;

namespace DHLSampleApi.Models.PackageQuote
{
    public class PackageQuote
    {
        public string? ContactAdress { get; set; }
        public string? WarehouseAddress { get; set; }

        public List<PackageDimensions>? PackageDimensions { get; set; }
    }
}

