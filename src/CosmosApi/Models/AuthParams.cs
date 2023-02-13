using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class AuthParams
    {
        [JsonProperty(PropertyName = "params")]
        public Params Parameters { get; set; }
    }

    public class Params
    {
        [JsonProperty(PropertyName = "max_memo_characters")]
        public string MaxMemoCharacters { get; set; }

        [JsonProperty(PropertyName = "tx_sig_limit")]
        public string txSigLimit { get; set; }

        [JsonProperty(PropertyName = "tx_size_cost_per_byte")]
        public string TxSizeCostPerByte { get; set; }

        [JsonProperty(PropertyName = "sig_verify_cost_ed25519")]
        public string SigVerifyCostEd25519 { get; set; }

        [JsonProperty(PropertyName = "sig_verify_cost_secp256k1")]
        public string SigVerifyCostSecp256k1 { get; set; }

        public Params(string maxMemoCharacters, string txSigLimit, string txSizeCostPerByte, string sigVerifyCostEd25519, string sigVerifyCostSecp256k1)
        {
            MaxMemoCharacters = maxMemoCharacters;
            this.txSigLimit = txSigLimit;
            TxSizeCostPerByte = txSizeCostPerByte;
            SigVerifyCostEd25519 = sigVerifyCostEd25519;
            SigVerifyCostSecp256k1 = sigVerifyCostSecp256k1;
        }
    }
}
