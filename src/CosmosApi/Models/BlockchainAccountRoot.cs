using CosmosApi.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace CosmosApi.Models
{
    public class BlockchainAccountRoot
    {
        [JsonProperty("accounts")]
        public IList<BlockchainAccount> Accounts { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        public BlockchainAccountRoot(){}

        public BlockchainAccountRoot (IList<BlockchainAccount> accounts, Pagination pagination)
        {
            Accounts = accounts;
            Pagination = pagination;
        }
    }
}
