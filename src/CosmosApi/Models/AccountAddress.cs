using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosApi.Models
{
    public class AccountAddress
    {
        [JsonProperty("account_address")]
        public string Account { get; set; }
        public AccountAddress (string account)
        {
            Account = account;
        }
    }
}

