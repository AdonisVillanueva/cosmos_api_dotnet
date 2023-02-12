using CosmosApi.Serialization;
using Newtonsoft.Json;
using System;
using System.Numerics;

namespace CosmosApi.Models
{
    public class Balance
    {
        public BalanceElement[]? Balances { get; set; }
        public Pagination? Pagination { get; set; }
    }

    public class BalanceElement
    {
        [JsonProperty(PropertyName = "denom")]
        public string? Denom { get; set; }

        [JsonProperty(PropertyName = "amount")]
        [JsonConverter(typeof(StringNumberConverter))]
        public BigInteger Amount { get; set; }
    }
}







