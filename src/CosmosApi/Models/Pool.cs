using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosApi.Models
{
    public class Pool
    {
        [JsonProperty("pool")]
        public IList<DecCoin> Pools { get; set; }
    }
}