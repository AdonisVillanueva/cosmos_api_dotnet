using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace CosmosApi.Models
{
    public class Supply
    {
        /// <summary>
        /// Initializes a new instance of the Supply class.
        /// </summary>
        /// 
        [JsonProperty(PropertyName = "supply")]
        public IList<Coin> Amount { get; set; }

        [JsonProperty(PropertyName = "pagination")]
        public Pagination Pagination { get; set; }
        public Supply()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Supply class.
        /// </summary>
        public Supply(IList<Coin> amount)
        {
            Amount = amount;
        }
    }
}