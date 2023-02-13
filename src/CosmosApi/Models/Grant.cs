using Newtonsoft.Json;
using System;

namespace CosmosApi.Models
{
    public class Grant
    {
        [JsonProperty("granter")]
        public string Granter { get; set; }

        [JsonProperty("grantee")]
        public string Grantee { get; set; }

        [JsonProperty("authorization")]
        public GrantAuthorization Authorization { get; set; }

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        public Grant(string granter, string grantee, GrantAuthorization authorization, DateTime expiration)
        {
            Granter = granter;
            Grantee = grantee;
            Authorization = authorization;
            Expiration = expiration;
        }
    }
}
