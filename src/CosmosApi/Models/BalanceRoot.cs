using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class BalanceRoot
    {
        [JsonProperty(PropertyName = "balances")]
        public Balance[]? Balances { get; set; }

        [JsonProperty(PropertyName = "pagination")]
        public Pagination? Pagination { get; set; }
    }
}