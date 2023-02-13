using ExtendedNumerics;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class Balance
    {
        [JsonProperty(PropertyName = "denom")]
        public string Denom { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public BigDecimal Amount { get; set; }

        public Balance() { }

        public Balance(string denom, BigDecimal amount)
        {
            Denom = denom;
            Amount = amount;
        }
    }
}