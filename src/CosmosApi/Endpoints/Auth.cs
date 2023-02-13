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
        public async Task<BlockchainAccountRoot> GetAuthAccountsAsync(string? paginationKey, int? paginationOffset, int? paginationLimit, 
            bool? paginationCountTotal, bool? paginationReverse, CancellationToken cancellationToken = default)
        {
            return await _clientGetter()
                .Request("cosmos/auth/v1beta1/accounts")
                .SetQueryParam("pagination.key",paginationKey)
                .SetQueryParam("pagination.offset",paginationOffset)
                .SetQueryParam("pagination.limit",paginationLimit)
                .SetQueryParam("pagination.count_total",paginationCountTotal)
                .SetQueryParam("pagination.reverse",paginationReverse)
                .GetJsonAsync<BlockchainAccountRoot>(cancellationToken: cancellationToken)
                .WrapExceptions();
        }
        public BlockchainAccountRoot GetAuthAccounts(string? paginationKey, int? paginationOffset, int? paginationLimit,
            bool? paginationCountTotal, bool? paginationReverse)
        {
            return GetAuthAccountsAsync(paginationKey, paginationOffset, paginationLimit,
            paginationCountTotal, paginationReverse)
            .Sync();
        }

        public async Task<ResponseWithHeight<BlockchainAccountRoot>> GetAuthModuleAccountsAsync(CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<BlockchainAccountRoot> rAccount = new();

            var clientResponse = await _clientGetter()
                                .Request("cosmos/auth/v1beta1/module_accounts")
                                .GetAsync()
                                .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rAccount.Height = (long)Convert.ToDouble(blockHeight);
            };

            rAccount.Result = await clientResponse.GetJsonAsync<BlockchainAccountRoot>()
                                .WrapExceptions();
            return rAccount;
        }

        public async Task<ResponseWithHeight<ModuleAccountRoot>> GetAuthModuleAccountsByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<ModuleAccountRoot> rAccount = new();

            var clientResponse = await _clientGetter()
                                .Request("cosmos/auth/v1beta1/module_accounts/", name)
                                .GetAsync()
                                .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rAccount.Height = (long)Convert.ToDouble(blockHeight);
            };

            rAccount.Result = await clientResponse.GetJsonAsync<ModuleAccountRoot>()
                                .WrapExceptions();
            return rAccount;
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

        public async Task<ResponseWithHeight<AccountAddress>> GetAuthAccountByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<AccountAddress> rAccount = new();

            var clientResponse = await _clientGetter()
                                .Request("cosmos/auth/v1beta1", "address_by_id", id)
                                .GetAsync()
                                .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rAccount.Height = (long)Convert.ToDouble(blockHeight);
            };

            rAccount.Result = await clientResponse.GetJsonAsync<AccountAddress>()
                                .WrapExceptions();
            return rAccount;
        }

        public ResponseWithHeight<AccountAddress> GetAuthAccountById(int id)
        {
            return GetAuthAccountByIdAsync(id)
                .Sync();
        }

        public async Task<AuthParams> GetAuthParamsAsync(CancellationToken cancellationToken = default)
        {
            return await _clientGetter()
                                .Request("cosmos/auth/v1beta1/params")
                                .GetJsonAsync<AuthParams>(cancellationToken)
                                .WrapExceptions();
        }
    }
}