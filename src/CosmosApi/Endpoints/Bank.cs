using CosmosApi.Extensions;
using CosmosApi.Models;
using Flurl.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosApi.Endpoints
{
    public class Bank : IBank
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public Bank(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }
        public async Task<ResponseWithHeight<Balance>> GetBankBalancesByAddressAsync(string address, CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<Balance> rBank = new();

            var clientResponse = await _clientGetter()
                                .Request("cosmos/bank/v1beta1/", "balances", address)
                                .GetAsync()
                                .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rBank.Height = (long)Convert.ToDouble(blockHeight);
            };

            rBank.Result = await clientResponse.GetJsonAsync<Balance>()
                                .WrapExceptions();
            return rBank;
        }
        public ResponseWithHeight<Balance> GetBankBalancesByAddress(string address)
        {
            return GetBankBalancesByAddressAsync(address)
                .Sync();
        }
    }
}