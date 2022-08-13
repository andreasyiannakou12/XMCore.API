using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;
using XMCore.API.Data;
using XMCore.API.Models;
using XMCore.API.Reponses;
using XMCore.API.Services;

namespace XMCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceSourceController : ControllerBase
    {
        private readonly PriceSourceDbContext _dbcontext;
        private readonly IPriceSourceService _priceSourceService;
        private readonly PriceDataDbContext _priceDataDbContext;

        public PriceSourceController(PriceSourceDbContext dbcontext, IPriceSourceService priceSourceService, PriceDataDbContext priceDataDbContext)
        {
            _dbcontext = dbcontext;
            _priceSourceService = priceSourceService;
            _priceDataDbContext = priceDataDbContext;
        }

        [HttpGet("GetAllPriceSources")]
        [Authorize]
        public async Task<IActionResult> GetAllPriceSources()
        {
            IEnumerable<PriceSource> priceSources;
            priceSources = await _dbcontext.PriceSource.ToListAsync();
            var response = new Response<IEnumerable<PriceSource>>(priceSources);
            if (priceSources == null || priceSources.Count() == 0) { response.Message = "No Sources found"; }
            return Ok(response);
        }

        [HttpPost("SaveBitcoinPricesBySourceCode")]
        [Authorize]
        public async Task<IActionResult> SaveBitcoinPricesBySourceCode(string sourceName, string currencyCode = "usd")
        {
            PriceData priceData;
            priceData = await _priceSourceService.GetFromSourceAndSaveRecord(sourceName, currencyCode);
            var response = new Response<PriceData>(priceData);
            if (priceData == null) { response.Message = "Source not found"; }
            return Ok(response);
        }

        [HttpPost("GetAllPriceData")]
        [Authorize]
        public async Task<IActionResult> GetAllPriceData()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<PriceData> priceData;
            priceData = await _priceDataDbContext.PriceData.ToListAsync();
            var response = new Response<IEnumerable<PriceData>>(priceData);
            if (priceData == null || priceData.Count() == 0) { response.Message = "No price data found"; }
            return Ok(response);
        }

        [HttpPost("DeleteBySourceDataId/{sourceDataId}")]
        [Authorize]
        public async Task<IActionResult> DeleteBySourceDataId(int sourceDataId)
        {
            EntityEntry<PriceData> priceData = null;
            var item = (from s in _priceDataDbContext.PriceData
                        where s.PriceDataId == sourceDataId
                        select s).FirstOrDefault<PriceData>();

            if (item != null)
            {
                priceData = _priceDataDbContext.PriceData.Remove(item);
                await _priceDataDbContext.SaveChangesAsync();
            }
            var response = new Response<string>(priceData.State.ToString());
            return Ok(response);
        }

        [HttpPost("DeleteByPriceSourceId/{priceSourceId}")]
        [Authorize]
        public async Task<IActionResult> DeleteByPriceSourceId(int priceSourceId)
        {
            EntityEntry<PriceData> priceData = null;
            var items = await (from s in _priceDataDbContext.PriceData
                               where s.PriceSourceId == priceSourceId
                               select s).ToListAsync<PriceData>();

            if (items.Count() > 0)
            {
                foreach (var item in items)
                {
                    _priceDataDbContext.PriceData.Remove(item);
                }
                await _priceDataDbContext.SaveChangesAsync();
            }

            var response = new Response<bool>(true);
            if (items == null || items.Count() == 0) { response.Message = "No price data found using the specified PriceSourceId"; }
            return Ok(response);
        }
    }
}
