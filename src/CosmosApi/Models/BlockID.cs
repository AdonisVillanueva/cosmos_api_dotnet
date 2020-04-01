using System.Net.Http;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class BlockID
    {
        /// <summary>
        /// Initializes a new instance of the BlockID class.
        /// </summary>
        public BlockID()
        {
        }

        /// <summary>
        /// Initializes a new instance of the BlockID class.
        /// </summary>
        public BlockID(byte[] hash = default(byte[]), BlockIDParts parts = default(BlockIDParts))
        {
            Hash = hash;
            Parts = parts;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hash")]
        [JsonConverter(typeof(HexStringByteArrayConverter))]
        public byte[] Hash { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "parts")]
        public BlockIDParts Parts { get; set; }

    }
}
