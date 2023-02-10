using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CosmosApi.Extensions;
using CosmosApi.Models;
using Flurl.Http;
using Flurl.Util;

namespace CosmosApi.Endpoints
{
    public class ResponseHeaders : IResponseHeaders
    {
        private IFlurlResponse _response;

        public ResponseHeaders(IFlurlResponse response)
        {
            _response = response;
        }
    }
}