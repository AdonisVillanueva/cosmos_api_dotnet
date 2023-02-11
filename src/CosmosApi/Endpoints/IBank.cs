using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Models;

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
        Task<ResponseWithHeight<Balance>> GetBankBalancesByAddressAsync(string address, CancellationToken cancellationToken = default);

        ResponseWithHeight<Balance> GetBankBalancesByAddress(string address);
    }
}
