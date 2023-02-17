using Newtonsoft.Json;

namespace CosmosApi.Models
{    
    public class Metadata
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "denom_units")]
        public DenomUnits[] DenomUnits { get; set; }

        [JsonProperty(PropertyName = "base")]
        public string Base { get; set; }

        [JsonProperty(PropertyName = "display")]
        public string Display { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "uri_hash")]
        public string UriHash { get; set; }
    }
}
