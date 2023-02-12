using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class TestAccount
    {
        public TestAccount Account { get; set; }

    }

    public class AccountUlong
    {
        [JsonProperty(PropertyName = "@type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string address { get; set; }

        [JsonProperty(PropertyName = "pub_key")]
        public PublicKey pub_key { get; set; }

        [JsonProperty(PropertyName = "account_number")]
        public string account_number { get; set; }

        [JsonProperty(PropertyName = "sequence")]
        public string sequence { get; set; }


    }
}
