using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class Balance
    {
        [JsonProperty(PropertyName = "balances")]
        public Coin[]? Coin { get; set; }

        [JsonProperty(PropertyName = "pagination")]
        public Pagination? Pagination { get; set; }
    }
}