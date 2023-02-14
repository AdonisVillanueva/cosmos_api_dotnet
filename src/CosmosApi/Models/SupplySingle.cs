using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosApi.Models
{
    public class SupplySingle
    {
        /// <summary>
        /// Initializes a new instance of the Supply class.
        /// </summary>
        /// 
        [JsonProperty(PropertyName = "amount")]
        public Coin Amount { get; set; }

        public SupplySingle()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Supply class.
        /// </summary>
        public SupplySingle(Coin coin)
        {
            Amount = coin;
        }
    }
}
