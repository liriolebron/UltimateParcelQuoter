using UltimateParcelQuoter.Models;

namespace UltimateParcelQuoter.Interfaces
{
    public interface IParcelQuoter
    {
        Task<string> Quote(PackageQuote packageQuote);
    }
}
