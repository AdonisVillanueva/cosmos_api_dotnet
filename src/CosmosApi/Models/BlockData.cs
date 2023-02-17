using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosApi.Models
{
    public class BlockData
    {
        public BlockData()
        {
        }

        public BlockData(IList<string>? transactions)
        {
            Transactions = transactions;
        }

        [JsonProperty(PropertyName = "txs")]
        public IList<string>? Transactions { get; set; }
    }
}