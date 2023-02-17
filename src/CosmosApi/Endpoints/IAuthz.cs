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
    public interface IAuthz
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
        Task<ResponseWithHeight<GrantRoot>> GetAuthzGrantsAsync(string granter, string grantee, string? messageTypeUrl, string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default,
            bool? paginationCountTotal = default, bool? paginationReverse = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the account information on blockchain.
        /// </summary>
        /// <param name='id'>
        /// id is the account number of the address to be queried.This field
        /// should have been an uint64(like all account numbers), and will be
        /// updated to uint64 in a future version of the auth query.
        /// </param>
        ResponseWithHeight<GrantRoot> GetAuthzGrants(string granter, string grantee, string? messageTypeUrl, string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default,
            bool? paginationCountTotal = default, bool? paginationReverse = default);

        Task<GrantRoot> GetAuthzGrantByGranterAsync(string granter, string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default,
        bool? paginationCountTotal = default, bool? paginationReverse = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the grant by granter information on blockchain.
        /// </summary>
        /// <param name='granter'>
        /// Account address.
        /// </param>
        GrantRoot GetAuthzGrantByGranter(string granter, string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default,bool? paginationCountTotal = default, bool? paginationReverse = default);

        /// <summary>
        /// Get the grant by grantee information on blockchain.
        /// </summary>
        /// <param name='grantee'>
        /// Account address.
        /// </param>
        Task<GrantRoot> GetAuthzGrantByGranteeAsync(string grantee, string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default,
            bool? paginationCountTotal = default, bool? paginationReverse = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the grant by grantee information on blockchain.
        /// </summary>
        /// <param name='grantee'>
        /// Account address.
        /// </param>
       GrantRoot GetAuthzGrantByGrantee(string granter, string? paginationKey = default, int? paginationOffset = default, int? paginationLimit = default,
            bool? paginationCountTotal = default, bool? paginationReverse = default);    
    }
}
