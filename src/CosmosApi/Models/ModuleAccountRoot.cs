using CosmosApi.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace CosmosApi.Models
{
    public class ModuleAccountRoot
    {
        [JsonProperty("account")]
        public BlockchainAccount Account { get; set; }
        public ModuleAccountRoot(){}

        public ModuleAccountRoot(BlockchainAccount account)
        {
            Account = account;
        }
    }
}
