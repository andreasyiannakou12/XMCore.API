using XMCore.API.Models;

namespace XMCore.API.Services
{
    public interface IPriceSourceService
    {
        Task<PriceData> GetFromSourceAndSaveRecord(string sourceName, string currencyCode);
    }
}