using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class DenomOwners
    {
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "balance")]
        public Balance Balance { get; set; }

        public DenomOwners() { }

        public DenomOwners(string address, Balance balance)
        {
            Address = address;
            Balance = balance;
        }
    }
}
