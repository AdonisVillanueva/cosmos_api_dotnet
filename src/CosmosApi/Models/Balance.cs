using CosmosApi.Serialization;
using Newtonsoft.Json;
using System;
using System.Numerics;

namespace CosmosApi.Models
{

    public class Balance
    {
        public BalanceElement[]? balances { get; set; }
        public Pagination? pagination { get; set; }
    }

    public class Pagination
    {
        [JsonProperty(PropertyName = "next_key")]
        public string? next_key { get; set; } = null;

        [JsonProperty(PropertyName = "total")]
        [JsonConverter(typeof(StringNumberConverter))]
        public Int32? total { get; set; }
    }

    public class BalanceElement
    {
        [JsonProperty(PropertyName = "denom")]
        public string? denom { get; set; }

        [JsonProperty(PropertyName = "amount")]
        [JsonConverter(typeof(StringNumberConverter))]
        public BigInteger amount { get; set; }
    }
}







