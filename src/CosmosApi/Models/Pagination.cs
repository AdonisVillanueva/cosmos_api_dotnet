using CosmosApi.Serialization;
using Newtonsoft.Json;
using System;

namespace CosmosApi.Models
{
    public class Pagination
    {
        /// <summary>
        /// Initializes a new instance of the Pagination class.
        /// </summary>
        public Pagination()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Pagination class.
        /// </summary>
        public Pagination(string? nextKey, int total)
        {
            NextKey = nextKey;
            Total = total;
        }

        [JsonProperty(PropertyName = "next_key")]
        public string? NextKey { get; set; } = null;

        [JsonProperty(PropertyName = "total")]
        [JsonConverter(typeof(StringNumberConverter))]
        public Int32? Total { get; set; }
    }
}
