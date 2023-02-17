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
        Task<ResponseWithHeight<Balance>> GetBankBalancesByAddressAsync(string address, string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default,
            bool? paginationCountTotal = default, bool? paginationReverse = default, CancellationToken cancellationToken = default);

        ResponseWithHeight<Balance> GetBankBalancesByAddress(string address, string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default,
            bool? paginationCountTotal = default, bool? paginationReverse = default);

        Task<ResponseWithHeight<Balance>> GetBankBalanceByAddressByDenomAsync(string address, string denom, string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default,
            bool? paginationCountTotal = default, bool? paginationReverse = default, CancellationToken cancellationToken = default);

        Task<DenomOwnersRoot> GetBankDenomOwnersByDenomAsync(string denom, CancellationToken cancellationToken = default);

        Task<ResponseWithHeight<DenomsMetadata>> GetDenomsMetadataAsync(string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default,
            bool? paginationCountTotal = default, bool? paginationReverse = default, CancellationToken cancellationToken = default);

        Task<ResponseWithHeight<BankParams>> GetBankParamsAsync(CancellationToken cancellationToken = default);

        Task<ResponseWithHeight<Balance>> GetBankSpendableBalancesByAddressAsync(string address, string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default,
            bool? paginationCountTotal = default, bool? paginationReverse = default, CancellationToken cancellationToken = default);
        Task<ResponseWithHeight<Supply>> GetBankSupplyAsync(string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default,
            bool? paginationCountTotal = default, bool? paginationReverse = default, CancellationToken cancellationToken = default);

        Task<ResponseWithHeight<SupplySingle>> GetBankDenomByDenomAsync(string denom, CancellationToken cancellationToken = default);
        
    }
}
