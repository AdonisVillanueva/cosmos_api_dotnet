﻿using CosmosApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosApi.Models
{
    public class Account : IAccount
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = null!;

        [JsonProperty("address")]
        public string Address { get; set; } = null!;

        [JsonProperty("pub_key")]
        public PublicKey PublicKey { get; set; } = null!;

        [JsonProperty("account_number")]
        public ulong AccountNumber { get; set; }
        [JsonProperty("sequence")]
        public ulong Sequence { get; set; }

        public Account()
        {
        }

        public Account(string address, string type, PublicKey publicKey, ulong accountNumber, ulong sequence)
        {            
            Type = type;
            Address = address;
            PublicKey = publicKey;
            AccountNumber = accountNumber;
            Sequence = sequence;
        }

        public PublicKey GetPublicKey()
        {
            return PublicKey;
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