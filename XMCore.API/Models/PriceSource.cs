namespace XMCore.API.Models
{
    public class PriceSource
    {
        public int PriceSourceId { get; set; }
        public string PriceSourceName { get; set; }
        public string PriceSourceCode { get; set; }
        public string PriceSourceEndpoint { get; set; }
        public string PriceSourceDocsEndpoint { get; set; }
    }
}
