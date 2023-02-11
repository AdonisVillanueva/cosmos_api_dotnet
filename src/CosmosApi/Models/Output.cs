using Newtonsoft.Json;
using System.Collections.Generic;

namespace CosmosApi.Models
{
    /// <summary>
    /// Output models transaction outputs.
    /// </summary>
    public class Output
    {
        [JsonProperty("address")]
        public string AccAddress { get; set; } = null!;

        [JsonProperty("coins")]
        public IList<Coin> Coins { get; set; } = null!;

        public Output()
        {
        }

        public Output(string accAddress, IList<Coin> coins)
        {
            AccAddress = accAddress;
            Coins = coins;
        }
    }
}