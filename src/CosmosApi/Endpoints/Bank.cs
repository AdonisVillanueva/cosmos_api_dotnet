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
        public async Task<ResponseWithHeight<BalanceRoot>> GetBankBalancesByAddressAsync(string address, string? paginationKey, int? paginationOffset, int? paginationLimit,
            bool? paginationCountTotal, bool? paginationReverse, CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<BalanceRoot> rBank = new();

            var clientResponse = await _clientGetter()
                                .Request("cosmos/bank/v1beta1/", "balances", address)
                                .GetAsync()
                                .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rBank.Height = (long)Convert.ToDouble(blockHeight);
            };

            rBank.Result = await clientResponse.GetJsonAsync<BalanceRoot>()
                                .WrapExceptions();
            return rBank;
        }
        public ResponseWithHeight<BalanceRoot> GetBankBalancesByAddress(string address, string? paginationKey, int? paginationOffset, int? paginationLimit,
            bool? paginationCountTotal, bool? paginationReverse)
        {
            return GetBankBalancesByAddressAsync(address, paginationKey, paginationOffset, paginationLimit, paginationCountTotal, paginationReverse)
                .Sync();
        }

        public async Task<DenomOwnersRoot> GetBankDenomOwnersByDenom(string denom, CancellationToken cancellationToken = default)
        {
             return await _clientGetter()
                                .Request("cosmos/bank/v1beta1/denom_owners", denom)
                                .GetJsonAsync<DenomOwnersRoot>()
                                .WrapExceptions();
        }

        public async Task<ResponseWithHeight<BalanceRoot>> GetBankBalanceByAddressByDenom(string address, string denom, string? paginationKey, int? paginationOffset, int? paginationLimit, bool? paginationCountTotal, bool? paginationReverse, CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<BalanceRoot> rBank = new();
            var clientResponse = await _clientGetter()
                                .Request("cosmos/bank/v1beta1/balances/", address)
                                .SetQueryParam("by_denom", denom)
                                .GetAsync()
                                .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rBank.Height = (long)Convert.ToDouble(blockHeight);
            };

            rBank.Result = await clientResponse.GetJsonAsync<BalanceRoot>()
                                .WrapExceptions();
            return rBank;
        }
    }
}