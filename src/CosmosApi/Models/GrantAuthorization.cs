using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosApi.Models
{
    public class GrantAuthorization
    {
        [JsonProperty("@type")]
        public string type { get; set; }

        public GrantAuthorization() { }

        public GrantAuthorization(string type)
        {
            this.type = type;
        }
    }

}
