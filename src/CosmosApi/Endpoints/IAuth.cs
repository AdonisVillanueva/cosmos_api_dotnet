using CosmosApi.Models;
using System.IO;
using System.Security.Principal;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosApi.Endpoints
{

    /// <summary>
    /// Authenticate accounts.
    /// </summary>
    public interface IAuth
    {
        /// <summary>
        /// Get the account information on blockchain.
        /// </summary>
        /// <param name='address'>
        /// Account address.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<ResponseWithHeight<IAccount>> GetAuthAccountByAddressAsync(string address, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the account information on blockchain.
        /// </summary>
        /// <param name='id'>
        /// id is the account number of the address to be queried.This field
        /// should have been an uint64(like all account numbers), and will be
        /// updated to uint64 in a future version of the auth query.
        /// </param>
        ResponseWithHeight<AccountAddress> GetAuthAccountById(int id);
        /// <summary>
        /// Get the account information on blockchain.
        /// </summary>
        /// <param name='id'>
        /// id is the account number of the address to be queried.This field
        /// should have been an uint64(like all account numbers), and will be
        /// updated to uint64 in a future version of the auth query.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<ResponseWithHeight<AccountAddress>> GetAuthAccountByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the account information on blockchain.
        /// </summary>
        /// <param name='address'>
        /// Account address.
        /// </param>
        ResponseWithHeight<IAccount> GetAuthAccountByAddress(string address);

        /// <summary>
        /// Get all accounts information on blockchain.
        /// </summary>
        Task<BlockchainAccountRoot> GetAuthAccountsAsync(string? paginationKey, int? paginationOffset, int? paginationLimit,
            bool? paginationCountTotal, bool? paginationReverse, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all accounts information on blockchain.
        /// </summary>
        BlockchainAccountRoot GetAuthAccounts(string? paginationKey, int? paginationOffset, int? paginationLimit,
            bool? paginationCountTotal, bool? paginationReverse);
    }
}
