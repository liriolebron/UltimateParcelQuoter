using System.Xml.Serialization;
using UltimateParcelQuoter.DTOs.Common;

namespace UltimateParcelQuoter.DTOs.UPSService
{
    [XmlRoot(ElementName = "PackageQuote")]
    public class UPSPackageQuoteDTO
    {        
        public string Source { get; set; }
        
        public string Destination { get; set; }        
        
        public List<PackageDimensions> Packages { get; set; }
    }
}

