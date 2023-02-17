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
        public async Task<ResponseWithHeight<Balance>> GetBankBalancesByAddressAsync(string address, string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default,
            bool? paginationCountTotal = default, bool? paginationReverse = default, CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<Balance> rBank = new();

            var clientResponse = await _clientGetter()
                                .Request("cosmos/bank/v1beta1/", "balances", address)
                                .SetQueryParam("pagination.key", paginationKey)
                                .SetQueryParam("pagination.offset", paginationKey)
                                .SetQueryParam("pagination.limit", paginationLimit)
                                .SetQueryParam("pagination.count_total", paginationCountTotal)
                                .SetQueryParam("agination.reverse", paginationReverse)
                                .GetAsync(cancellationToken)
                                .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rBank.Height = (long)Convert.ToDouble(blockHeight);
            };

            rBank.Result = await clientResponse.GetJsonAsync<Balance>()
                                .WrapExceptions();
            return rBank;
        }
        public ResponseWithHeight<Balance> GetBankBalancesByAddress(string address, string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default,
            bool? paginationCountTotal = default, bool? paginationReverse = default)
        {
            return GetBankBalancesByAddressAsync(address, paginationKey, paginationOffset, paginationLimit, paginationCountTotal, paginationReverse)
                .Sync();
        }

        public async Task<DenomOwnersRoot> GetBankDenomOwnersByDenomAsync(string denom, CancellationToken cancellationToken = default)
        {
             return await _clientGetter()
                                .Request("cosmos/bank/v1beta1/denom_owners", denom)
                                .GetJsonAsync<DenomOwnersRoot>(cancellationToken)
                                .WrapExceptions();
        }

        public async Task<ResponseWithHeight<Balance>> GetBankBalanceByAddressByDenomAsync(string address, string denom, string? paginationKey = default, 
            int? paginationOffset = default, int? paginationLimit = default, bool? paginationCountTotal = default, bool? paginationReverse = default, CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<Balance> rBank = new();
            var clientResponse = await _clientGetter()
                                .Request("cosmos/bank/v1beta1/balances/", address)
                                .SetQueryParam("by_denom", denom)
                                .SetQueryParam("pagination.key", paginationKey)
                                .SetQueryParam("pagination.offset", paginationKey)
                                .SetQueryParam("pagination.limit", paginationLimit)
                                .SetQueryParam("pagination.count_total", paginationCountTotal)
                                .SetQueryParam("agination.reverse", paginationReverse)
                                .GetAsync(cancellationToken)
                                .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rBank.Height = (long)Convert.ToDouble(blockHeight);
            };

            rBank.Result = await clientResponse.GetJsonAsync<Balance>()
                                .WrapExceptions();
            return rBank;
        }

        public async Task<ResponseWithHeight<DenomsMetadata>> GetDenomsMetadataAsync(string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default, 
            bool? paginationCountTotal = default, bool? paginationReverse = default, CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<DenomsMetadata> rBank = new();
            var clientResponse = await _clientGetter()
                                .Request("cosmos/bank/v1beta1/denoms_metadata")
                                .SetQueryParam("pagination.key", paginationKey)
                                .SetQueryParam("pagination.offset", paginationKey)
                                .SetQueryParam("pagination.limit", paginationLimit)
                                .SetQueryParam("pagination.count_total", paginationCountTotal)
                                .SetQueryParam("agination.reverse", paginationReverse)
                                .GetAsync(cancellationToken)
                                .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rBank.Height = (long)Convert.ToDouble(blockHeight);
            };

            rBank.Result = await clientResponse.GetJsonAsync<DenomsMetadata>()
                                .WrapExceptions();
            return rBank;
        }

        public async Task<ResponseWithHeight<BankParams>> GetBankParamsAsync(CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<BankParams> rBank = new();

            var clientResponse = await _clientGetter()
                        .Request("/cosmos/bank/v1beta1/params")
                        .GetAsync(cancellationToken)
                        .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rBank.Height = (long)Convert.ToDouble(blockHeight);
            };

            rBank.Result = await clientResponse.GetJsonAsync<BankParams>()
                                .WrapExceptions();
            return rBank;
        }

        public async Task<ResponseWithHeight<Balance>> GetBankSpendableBalancesByAddressAsync(string address, string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default, bool? paginationCountTotal = default, bool? paginationReverse = default, CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<Balance> rBank = new();
            var clientResponse = await _clientGetter()
                                .Request("cosmos/bank/v1beta1/spendable_balances/", address)
                                .SetQueryParam("by_denom", address)
                                .SetQueryParam("pagination.key", paginationKey)
                                .SetQueryParam("pagination.offset", paginationKey)
                                .SetQueryParam("pagination.limit", paginationLimit)
                                .SetQueryParam("pagination.count_total", paginationCountTotal)
                                .SetQueryParam("agination.reverse", paginationReverse)
                                .GetAsync(cancellationToken)
                                .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rBank.Height = (long)Convert.ToDouble(blockHeight);
            };

            rBank.Result = await clientResponse.GetJsonAsync<Balance>()
                                .WrapExceptions();
            return rBank;
        }

        public async Task<ResponseWithHeight<Supply>> GetBankSupplyAsync(string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default, bool? paginationCountTotal = default, bool? paginationReverse = default, CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<Supply> rBank = new();

            var clientResponse = await _clientGetter()
                        .Request("/cosmos/bank/v1beta1/supply")
                        .GetAsync(cancellationToken)
                        .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rBank.Height = (long)Convert.ToDouble(blockHeight);
            };

            rBank.Result = await clientResponse.GetJsonAsync<Supply>()
                                .WrapExceptions();
            return rBank;
        }

        public async Task<ResponseWithHeight<SupplySingle>> GetBankDenomByDenomAsync(string denom, CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<SupplySingle> rBank = new();

            var clientResponse = await _clientGetter()
                        .Request("/cosmos/bank/v1beta1/supply/by_denom")
                        .SetQueryParam("denom", denom)
                        .GetAsync(cancellationToken)
                        .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rBank.Height = (long)Convert.ToDouble(blockHeight);
            };

            rBank.Result = await clientResponse.GetJsonAsync<SupplySingle>()
                                .WrapExceptions();
            return rBank;
        }
    }
}