using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosApi.Models
{
    public partial class BaseAccount : IAccount
    {
        [JsonProperty("account")]
        public Account Account { get; set; }

        public ulong GetAccountNumber()
        {
            return Account.AccountNumber;
        }

        public PublicKey GetPublicKey()
        {
            return Account.PublicKey;
        }

        public ulong GetSequence()
        {
            return Account.Sequence;
        }
    }
}