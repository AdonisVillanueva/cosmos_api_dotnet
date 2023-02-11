using Flurl.Http;
using System;

namespace CosmosApi
{
    public class CosmosSerializationException : Exception
    {
        public CosmosSerializationException(string? message) : base(message)
        {
        }

        public CosmosSerializationException(FlurlParsingException ex) : base(ex.Message, ex)
        {
        }
    }
}