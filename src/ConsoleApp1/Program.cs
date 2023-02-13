﻿using CosmosApi;
using CosmosApi.Models;
using Flurl;
using Flurl.Http;
using Flurl.Util;

using var client = new CosmosApiBuilder()
    .UseBaseUrl("http://localhost:1317")
    .CreateClient();

string address = "cosmos1lmgm2eta9wpyr75k5740a802p07mfg3x843pzt";

//Flurl example
    var balance =
    await client.Bank.GetBankBalancesByAddressAsync(address);


    IFlurlResponse singleGeocodeResponse = (IFlurlResponse)await "http://localhost:1317"
        .AppendPathSegments("cosmos", "bank", "v1beta1", "balances")
        .AppendPathSegment(address)
        .GetAsync();

    Console.WriteLine(singleGeocodeResponse);

    IReadOnlyNameValueList<string> headers = singleGeocodeResponse.Headers;
    string blockHeight = headers.FirstOrDefault(h => h.Name == "Grpc-Metadata-X-Cosmos-Block-Height").Value;
    Console.WriteLine(blockHeight);

    var responseBalance = await singleGeocodeResponse.GetJsonAsync<Balance>();

    Console.WriteLine(responseBalance);

//var nodeinfo = await client.GaiaRest.GetNodeInfoAsync();
//Console.WriteLine(nodeinfo);

var nodeinfo = await client.Auth.GetAuthAccountByAddressAsync("cosmos1lmgm2eta9wpyr75k5740a802p07mfg3x843pzt");
Console.WriteLine(nodeinfo);


var accounts = await client.Auth.GetAuthAccountsAsync(null,null,null,null,null);
Console.WriteLine(accounts);

var accountbyid = await client.Auth.GetAuthAccountByIdAsync(1);
Console.WriteLine(accountbyid);
