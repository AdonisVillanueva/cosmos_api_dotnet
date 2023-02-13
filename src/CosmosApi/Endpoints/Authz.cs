using CosmosApi.Extensions;
using CosmosApi.Models;
using Flurl.Http;
using System;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosApi.Endpoints
{
    public class Authz : IAuthz
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public Authz(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }
        public async Task<ResponseWithHeight<GrantRoot>> GetAuthzGrantsAsync(string granter, string grantee, string? messageTypeUrl,string? paginationKey, int? paginationOffset, int? paginationLimit, 
            bool? paginationCountTotal, bool? paginationReverse, CancellationToken cancellationToken = default)
        {
            ResponseWithHeight<GrantRoot> rGrant = new();

            var clientResponse = await _clientGetter()
                .Request("cosmos/authz/v1beta1/grants")
                .SetQueryParam("granter", granter)
                .SetQueryParam("grantee", grantee)
                .SetQueryParam("msg_type_url",messageTypeUrl)
                .SetQueryParam("pagination.key", paginationKey)
                .SetQueryParam("pagination.offset",paginationOffset)
                .SetQueryParam("pagination.limit",paginationLimit)
                .SetQueryParam("pagination.count_total",paginationCountTotal)
                .SetQueryParam("pagination.reverse",paginationReverse)
                .GetAsync()
                .WrapExceptions();

            if (clientResponse.Headers.TryGetFirst("Grpc-Metadata-X-Cosmos-Block-Height", out string blockHeight))
            {
                rGrant.Height = (long)Convert.ToDouble(blockHeight);
            };

            rGrant.Result = await clientResponse.GetJsonAsync<GrantRoot>()
                                .WrapExceptions();
            return rGrant;
        }
        public ResponseWithHeight<GrantRoot> GetAuthzGrants(string granter, string grantee, string? messageTypeUrl, string? paginationKey, int? paginationOffset, int? paginationLimit,
            bool? paginationCountTotal, bool? paginationReverse)
        {
            return GetAuthzGrantsAsync(granter, grantee, messageTypeUrl, paginationKey, paginationOffset, paginationLimit,
            paginationCountTotal, paginationReverse)
            .Sync();
        }

        public async Task<GrantRoot> GetAuthzGrantByGranteeAsync(string grantee, string? paginationKey, int? paginationOffset, int? paginationLimit,
            bool? paginationCountTotal, bool? paginationReverse, CancellationToken cancellationToken = default)
        {
 
            return await _clientGetter()
                        .Request("cosmos/authz/v1beta1/grants","grantee", grantee)
                        .SetQueryParam("pagination.key", paginationKey)
                        .SetQueryParam("pagination.offset", paginationOffset)
                        .SetQueryParam("pagination.limit", paginationLimit)
                        .SetQueryParam("pagination.count_total", paginationCountTotal)
                        .SetQueryParam("pagination.reverse", paginationReverse)
                        .GetJsonAsync< GrantRoot>(cancellationToken)
                        .WrapExceptions();
        }

        public GrantRoot GetAuthzGrantByGrantee(string grantee, string? paginationKey, int? paginationOffset, int? paginationLimit,
            bool? paginationCountTotal, bool? paginationReverse)
        {
            return GetAuthzGrantByGranteeAsync(grantee, paginationKey, paginationOffset, paginationLimit,
            paginationCountTotal, paginationReverse)
                .Sync();
        }

        public async Task<GrantRoot> GetAuthzGrantByGranterAsync(string granter, string? paginationKey, int? paginationOffset, int? paginationLimit, bool? paginationCountTotal, 
            bool? paginationReverse, CancellationToken cancellationToken = default)
        {

            return await _clientGetter()
                        .Request("cosmos/authz/v1beta1/grants", "grantee", granter)
                        .SetQueryParam("pagination.key", paginationKey)
                        .SetQueryParam("pagination.offset", paginationOffset)
                        .SetQueryParam("pagination.limit", paginationLimit)
                        .SetQueryParam("pagination.count_total", paginationCountTotal)
                        .SetQueryParam("pagination.reverse", paginationReverse)
                        .GetJsonAsync<GrantRoot>(cancellationToken)
                        .WrapExceptions();
        }

        public GrantRoot GetAuthzGrantByGranter(string grantee, string? paginationKey, int? paginationOffset, int? paginationLimit,
    bool? paginationCountTotal, bool? paginationReverse)
        {
            return GetAuthzGrantByGranterAsync(grantee, paginationKey, paginationOffset, paginationLimit,
            paginationCountTotal, paginationReverse).Sync();
        }
    }
}