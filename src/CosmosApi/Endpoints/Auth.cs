using CosmosApi.Extensions;
using CosmosApi.Models;
using Flurl.Http;
using System;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosApi.Endpoints
{
    public class Auth : IAuth
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public Auth(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }
        public Task<IAccount> GetAuthAccountsAsync(CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("cosmos/auth/v1beta1/accounts")
                .GetJsonAsync<IAccount>(cancellationToken: cancellationToken)
                .WrapExceptions();
        }
        public IAccount GetAuthAccounts()
        {
            return GetAuthAccountsAsync()
            .Sync();
        }

        public async Task<ResponseWithHeight<IAccount>> GetAuthAccountByAddressAsync(string address, CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<IAccount> rAccount = new();

            var clientResponse = await _clientGetter()
                                .Request("cosmos/auth/v1beta1", "accounts", address)
                                .GetAsync()
                                .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rAccount.Height = (long)Convert.ToDouble(blockHeight);
            };

            rAccount.Result = await clientResponse.GetJsonAsync<BaseAccount>()
                                .WrapExceptions();
            return rAccount;
        }

        public ResponseWithHeight<IAccount> GetAuthAccountByAddress(string address)
        {
            return GetAuthAccountByAddressAsync(address)
                .Sync();
        }
    }
}