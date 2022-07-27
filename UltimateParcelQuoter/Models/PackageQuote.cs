using System;
namespace UltimateParcelQuoter.Models
{
    public class PackageQuote
    {
        public string SourceAddress { get; set; }
        public string DestinationAddress{ get; set; }

        public List<Package> Packages { get; set; }
    }
}

