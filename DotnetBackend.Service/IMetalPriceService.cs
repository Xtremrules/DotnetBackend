using DotnetBackend.Core.DTO;

namespace DotnetBackend.Service
{
    public interface IMetalPriceService
    {
        Task<GoldSilverResponse> GetGoldSilverPrice();
    }
}
