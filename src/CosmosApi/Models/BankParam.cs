using Newtonsoft.Json;

namespace CosmosApi.Models
{

    public class BankParams
    {
        [JsonProperty(PropertyName = "params")]
        public BankParams Params { get; set; }
    }

    public class BankParam
    {
        [JsonProperty(PropertyName = "send_enabled")]
        public SendEnabled[] SendEnabled { get; set; }

        [JsonProperty(PropertyName = "default_send_enabled")]
        public bool DefaultSendEnabled { get; set; }

        public BankParam() { }

        public BankParam(SendEnabled[] sendEnabled, bool defaultSendEnabled)
        {
            SendEnabled = sendEnabled;
            DefaultSendEnabled = defaultSendEnabled;
        }
    }
}
