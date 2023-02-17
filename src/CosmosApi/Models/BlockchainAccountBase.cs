using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosApi.Models
{
    public class BlockchainAccountBase
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("pub_key")]
        public PublicKey PublicKey { get; set; }

        [JsonProperty("account_number")]
        public ulong AccountNumber { get; set; }

        [JsonProperty("sequence")]
        public ulong Sequence { get; set; }

        public BlockchainAccountBase() { }

        public BlockchainAccountBase(string address, PublicKey publicKey, ulong accountNumber, ulong sequence)
        {
            Address = address;
            PublicKey = publicKey;
            AccountNumber = accountNumber;
            Sequence = sequence;
        }
    }
}