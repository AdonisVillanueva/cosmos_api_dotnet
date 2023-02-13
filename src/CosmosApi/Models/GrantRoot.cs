using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosApi.Models
{
    public class GrantRoot
    {
        [JsonProperty("grants")]
        public IList<Grant> Grants { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
