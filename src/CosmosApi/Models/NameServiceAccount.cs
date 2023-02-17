using CosmosApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NameserviceApi.Models
{
    public class NameServiceAccount : IAccount
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = null!;

        [JsonProperty("address")]
        public string Address { get; set; } = null!;

        [JsonProperty("pub_key")]
        public string PublicKey { get; set; } = null!;

        [JsonProperty("account_number")]
        public ulong AccountNumber { get; set; }
        [JsonProperty("sequence")]
        public ulong Sequence { get; set; }

        public NameServiceAccount()
        {
        }

        public NameServiceAccount(string address, string type, string publicKey, ulong accountNumber, ulong sequence)
        {            
            Type = type;
            Address = address;
            PublicKey = publicKey;
            AccountNumber = accountNumber;
            Sequence = sequence;
        }

        public PublicKey GetPublicKey()
        {
            return new PublicKey()
            {
                Type = null,
                Key = PublicKey
            };
        }

        public ulong GetSequence()
        {
            return Sequence;
        }

        public ulong GetAccountNumber()
        {
            return AccountNumber;
        }
    }
}