using System.ComponentModel.DataAnnotations.Schema;

namespace XMCore.API.Models
{
    public class PriceData
    {
        public int PriceDataId { get; set; }
        public string? volume { get; set; }
        public string? last { get; set; }
        public string? percent_change_24 { get; set; }
        public string? timestamp { get; set; }
        public string? bid { get; set; }
        public string? vwap { get; set; }
        public string? high { get; set; }
        public string? low { get; set; }
        public string? open_24 { get; set; }
        public string? ask { get; set; }
        public string? open { get; set; }
        public string? mid { get; set; }
        public string? last_price { get; set; }
        public DateTime CreateDate {get; set; }

        [ForeignKey("PriceSource")]
        public int PriceSourceId { get; set; }
        public string? PriceSourceName { get; set; }
        public virtual PriceSource PriceSource { get; set; }
        public string Currency { get; set; }
    }
}
