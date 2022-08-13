using XMCore.API.Data;
using XMCore.API.Models;

namespace XMCore.API.Services
{
    public class PriceSourceService : IPriceSourceService
    {
        private readonly PriceSourceDbContext _dbcontext;
        private readonly PriceDataDbContext _priceDataDbContext;

        public PriceSourceService(PriceSourceDbContext dbcontext, PriceDataDbContext priceDataDbContext)
        {
            _dbcontext = dbcontext;
            _priceDataDbContext = priceDataDbContext;
        }

        public async Task<PriceData> GetFromSourceAndSaveRecord(string sourceName, string currencyCode)
        {
            PriceData? item = null;
            HttpResponseMessage response = new HttpResponseMessage();
            PriceSource ? pc = (from s in _dbcontext.PriceSource
                              where s.PriceSourceName == sourceName
                              select s).FirstOrDefault<PriceSource>();

            if (pc != null)
            {
                if (currencyCode != "usd")
                {
                    pc.PriceSourceEndpoint = pc.PriceSourceEndpoint.Replace("usd", currencyCode);
                }

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(pc.PriceSourceEndpoint);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    item = await response.Content.ReadFromJsonAsync<PriceData>();
                    if(item != null)
                    {
                        item.CreateDate = DateTime.Now;
                        item.PriceSourceId = pc.PriceSourceId;
                        item.PriceSourceName = pc.PriceSourceName;
                        item.Currency = currencyCode;
                        var asd = await _priceDataDbContext.PriceData.AddAsync(item);
                        await _priceDataDbContext.SaveChangesAsync();
                    }
                }
            }

            return item;
        }
    }
}
