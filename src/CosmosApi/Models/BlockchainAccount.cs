using CosmosApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosApi.Models
{
    public class BlockchainAccount
    {
        [JsonProperty(PropertyName = "@type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "pub_key")]
        public PublicKey PublicKey { get; set; }

        [JsonProperty(PropertyName = "account_number")]
        public ulong AccountNumber { get; set; }

        [JsonProperty(PropertyName = "sequence")]
        public string Sequence { get; set; }

        [JsonProperty(PropertyName = "base_account")]
        public BlockchainAccountBase BaseAccount { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "permissions")]
        public string[] Permissions { get; set; }

        public BlockchainAccount()
        { }

        public BlockchainAccount(string @type, BlockchainAccountBase baseAccount, string address, PublicKey pubKey, ulong accountNumber, string sequence, string name, string[] permissions)
        {
            Type = @type;
            BaseAccount = baseAccount;
            Address = address;
            PublicKey = pubKey;
            AccountNumber = accountNumber;
            Sequence = sequence;
            Name = name;
            Permissions = permissions;
        }
    }
}
