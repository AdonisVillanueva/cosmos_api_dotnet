using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class DenomOwnersRoot
    {
        [JsonProperty(PropertyName = "denom_owners")]
        public DenomOwners[] DenomOwners { get; set; }

        [JsonProperty(PropertyName = "pagination")]
        public Pagination? Pagination { get; set; }
    }
}

