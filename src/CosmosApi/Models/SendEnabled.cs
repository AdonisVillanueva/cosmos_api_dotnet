using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosApi.Models
{
    public class SendEnabled
    {
        [JsonProperty(PropertyName = "denom")]
        public string Denom { get; set; }

        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        public SendEnabled() { }

        public SendEnabled(string denom, bool enabled)
        {
            Denom = denom;
            Enabled = enabled;
        }
    }
}
