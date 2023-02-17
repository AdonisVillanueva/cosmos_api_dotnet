using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class DenomsMetadata
    {
        [JsonProperty(PropertyName = "metadatas")]
        public Metadata[] Metadatas { get; set; }

        [JsonProperty(PropertyName = "pagination")]
        public Pagination Pagination { get; set; }
    }

}