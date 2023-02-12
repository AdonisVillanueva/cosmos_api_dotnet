using CosmosApi.Models;

namespace CosmosApi.Test.TestData
{
    public class NodeInfoData
    {
        public static NodeStatus NodeStatus = new()
        {
            NodeInfo = new NodeInfo()
            {
                ProtocolVersion = new ProtocolVersion()
                {
                    P2p = 7,
                    Block = 10,
                    App = 0
                },
                Id = "251236d391b489c6ebcdfcf6c22767f445a1fd99",
                ListenAddr = "tcp://0.0.0.0:26656",
                Network = "IgniteTest",
                Version = "0.32.9",
                Channels = "QCAhIiMwOGBhAA==",
                Moniker = "IgniteTest",
                Other = new OtherVersionsInformation()
                {
                    TxIndex = "on",
                    RpcAddress = "tcp://0.0.0.0:26657"
                }
            },
            ApplicationVersion = new AplicationVersion()
            {
                BuildDep = new BuildDep {
                    Path = "cloud.google.com/go",
                    Version = "v0.105.0",
                    Sum = "h1:DNtEKRBAAzeS4KyIory52wWHuClNaXJ5x1F7xa4q+5Y="
                },
                Name = "gaia",   
                AppName = "gaiacli",
                Version = "",
                Commit = "",
                BuildTags = "netgo,ledger",
                Go = "go version go1.14.2 linux/amd64",
                CosmosSDKVersion = "v0.46.7",                
            }
        };
    }
}