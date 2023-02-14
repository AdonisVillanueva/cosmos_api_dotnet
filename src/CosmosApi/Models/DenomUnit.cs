using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class DenomUnits
    {
        [JsonProperty(PropertyName = "denom")]
        public string Denom { get; set; }

        [JsonProperty(PropertyName = "exponent")]
        public int Exponent { get; set; }

        [JsonProperty(PropertyName = "aliases")]
        public string[] Aliases { get; set; }
    }
}
