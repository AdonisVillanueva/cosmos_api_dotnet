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
        public Pagination(string? next_key, int total)
        {
            Next_Key = next_key;
            Total = total;
        }

        [JsonProperty(PropertyName = "next_key")]
        public string? Next_Key { get; set; } = null;

        [JsonProperty(PropertyName = "total")]
        [JsonConverter(typeof(StringNumberConverter))]
        public Int32? Total { get; set; }
    }
}
