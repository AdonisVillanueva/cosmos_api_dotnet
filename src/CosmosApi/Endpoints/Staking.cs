﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Extensions;
using CosmosApi.Models;
using Flurl.Http;

namespace CosmosApi.Endpoints
{
    internal class Staking : IStaking
    {
        private readonly Func<IFlurlClient> _clientGetter;

        public Staking(Func<IFlurlClient> clientGetter)
        {
            _clientGetter = clientGetter;
        }
        
        public Task<ResponseWithHeight<IList<Delegation>>> GetDelegationsAsync(string delegatorAddr, CancellationToken cancellationToken = default)
        {
            return _clientGetter()
                .Request("staking", "delegators", delegatorAddr, "delegations")
                .GetJsonAsync<ResponseWithHeight<IList<Delegation>>>(cancellationToken)
                .WrapExceptions();
        }

        public ResponseWithHeight<IList<Delegation>> GetDelegations(string delegatorAddr)
        {
            return GetDelegationsAsync(delegatorAddr)
                .Sync();
        }

        public Task<TypeValue<StdTx>> PostDelegationsAsync(DelegateRequest request, CancellationToken cancellationToken = default)
        {
            var baseRequest = new BaseReqWithSimulate(request.BaseReq, false);
            request = new DelegateRequest(baseRequest, request.DelegatorAddress, request.ValidatorAddress, request.Amount);
            return _clientGetter()
                .Request("staking", "delegators", request.DelegatorAddress, "delegations")
                .PostJsonAsync(request, cancellationToken)
                .WrapExceptions()
                .ReceiveJson<TypeValue<StdTx>>()
                .WrapExceptions();
        }

        public TypeValue<StdTx> PostDelegations(DelegateRequest request)
        {
            return PostDelegationsAsync(request)
                .Sync();
        }

        public Task<GasEstimateResponse> PostDelegationsSimulationAsync(DelegateRequest request,
            CancellationToken cancellationToken = default)
        {
            var baseRequest = new BaseReqWithSimulate(request.BaseReq, true);
            request = new DelegateRequest(baseRequest, request.DelegatorAddress, request.ValidatorAddress, request.Amount);
            return _clientGetter()
                .Request("staking", "delegators", request.DelegatorAddress, "delegations")
                .PostJsonAsync(request, cancellationToken)
                .WrapExceptions()
                .ReceiveJson<GasEstimateResponse>()
                .WrapExceptions();
        }

        public GasEstimateResponse PostDelegationsSimulation(DelegateRequest request)
        {
            return PostDelegationsSimulationAsync(request)
                .Sync();
        }
    }
    
}