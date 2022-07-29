using System.Xml.Serialization;

namespace UltimateParcelQuoter.DTOs.UPSService
{
    [XmlRoot(ElementName = "PackageQuoteResponse")]
    public class UPSPackageQuoteResponseDTO
    {
        public double Quote { get; set; }
    }
}
