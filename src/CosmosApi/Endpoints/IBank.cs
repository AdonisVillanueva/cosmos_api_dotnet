using CosmosApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosApi.Endpoints
{

    /// <summary>
    /// Create and broadcast transactions.
    /// </summary>
    public partial interface IBank
    {
        /// <summary>
        /// Get the account balances.
        /// </summary>
        /// <param name='address'>
        /// Account address in bech32 format.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<ResponseWithHeight<BalanceRoot>> GetBankBalancesByAddressAsync(string address, string? paginationKey, int? paginationOffset, int? paginationLimit,
            bool? paginationCountTotal, bool? paginationReverse, CancellationToken cancellationToken = default);

        ResponseWithHeight<BalanceRoot> GetBankBalancesByAddress(string address, string? paginationKey, int? paginationOffset, int? paginationLimit,
            bool? paginationCountTotal, bool? paginationReverse);

        Task<ResponseWithHeight<BalanceRoot>> GetBankBalanceByAddressByDenom(string address, string denom, string? paginationKey, int? paginationOffset, int? paginationLimit,
            bool? paginationCountTotal, bool? paginationReverse, CancellationToken cancellationToken = default);

        Task<DenomOwnersRoot> GetBankDenomOwnersByDenom(string denom, CancellationToken cancellationToken = default);
    }
}
