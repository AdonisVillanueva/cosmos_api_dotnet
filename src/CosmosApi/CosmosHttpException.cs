﻿using Flurl.Http;
using System;
using System.Net.Http;

namespace CosmosApi
{
    public class CosmosHttpException : Exception
    {
        /// <summary>The HttpRequestMessage associated with this call.</summary>
        public HttpRequestMessage Request { get; }

        /// <summary>
        /// HttpResponseMessage associated with the call if the call completed, otherwise null.
        /// </summary>
        public HttpResponseMessage? Response { get; }

        /// <summary>DateTime the moment the request was sent.</summary>
        public DateTime StartedUtc { get; }

        /// <summary>DateTime the moment a response was received.</summary>
        public DateTime? EndedUtc { get; }

        /// <summary>Called url.</summary>
        public string Url { get; }

        internal CosmosHttpException(FlurlHttpException innerException) : base(innerException.Message, innerException)
        {
            Request = (HttpRequestMessage)innerException.Call.Request;
            Response = (HttpResponseMessage?)innerException.Call.Response;
            EndedUtc = innerException.Call.EndedUtc;
            StartedUtc = innerException.Call.StartedUtc;
            Url = innerException.Call.Request.Url;
        }
    }
}