using CosmosApi;
using CosmosApi.Models;
using Flurl;
using Flurl.Http;
using Flurl.Util;

using var client = new CosmosApiBuilder()
    .UseBaseUrl("http://localhost:1317")
    .CreateClient();

string address = "cosmos1lmgm2eta9wpyr75k5740a802p07mfg3x843pzt";

//Flurl example

    //IFlurlResponse singleGeocodeResponse = (IFlurlResponse)await "http://localhost:1317"
    //    .AppendPathSegments("cosmos", "bank", "v1beta1", "balances")
    //    .AppendPathSegment(address)
    //    .GetAsync();

    //Console.WriteLine(singleGeocodeResponse);

    //IReadOnlyNameValueList<string> headers = singleGeocodeResponse.Headers;
    //string blockHeight = headers.FirstOrDefault(h => h.Name == "Grpc-Metadata-X-Cosmos-Block-Height").Value;
    //Console.WriteLine(blockHeight);

    //var responseBalance = await singleGeocodeResponse.GetJsonAsync<Balance>();

    //Console.WriteLine(responseBalance);

var nodeinfo = await client.GaiaRest.GetNodeInfoAsync();
Console.WriteLine(nodeinfo);

var account = await client.Auth.GetAuthAccountByAddressAsync("cosmos1lmgm2eta9wpyr75k5740a802p07mfg3x843pzt");
Console.WriteLine(account);


var accounts = await client.Auth.GetAuthAccountsAsync(null,null,null,null,null);
Console.WriteLine(accounts);

var accountbyid = await client.Auth.GetAuthAccountByIdAsync(1);
Console.WriteLine(accountbyid);

var moduleaccounts = await client.Auth.GetAuthModuleAccountsAsync();
Console.WriteLine(moduleaccounts);

var accountbyname = await client.Auth.GetAuthModuleAccountsByNameAsync("transfer");
Console.WriteLine(moduleaccounts);

var authparams = await client.Auth.GetAuthParamsAsync();
Console.WriteLine(authparams);

var grants = await client.Authz.GetAuthzGrantsAsync("cosmos1lmgm2eta9wpyr75k5740a802p07mfg3x843pzt", "cosmos156ww7tt8g0wsdqucxpastq44s9htn55jkkcu2d",null,null,null,null,null,null);
Console.WriteLine(grants);

var grantee = await client.Authz.GetAuthzGrantByGranteeAsync("cosmos1lmgm2eta9wpyr75k5740a802p07mfg3x843pzt",null,null,null,null,null);
Console.WriteLine(grantee.Grants.FirstOrDefault());

var granter = await client.Authz.GetAuthzGrantByGranterAsync("cosmos1lmgm2eta9wpyr75k5740a802p07mfg3x843pzt", null, null, null, null, null);
Console.WriteLine(granter);

var balance = await client.Bank.GetBankBalancesByAddressAsync(address, null, null, null, null, null);
Console.WriteLine(balance.Result);

var denom = await client.Bank.GetBankDenomOwnersByDenomAsync("stake");
Console.WriteLine(denom.DenomOwners.FirstOrDefault());

var balanceDenom = await client.Bank.GetBankBalanceByAddressByDenomAsync(address,"stake",null,null,null,null,null);
Console.WriteLine(balanceDenom.Result);

var denomsMetadata = await client.Bank.GetDenomsMetadataAsync(null, null, null, null, null);
Console.WriteLine(denomsMetadata.Result);

var bankparams = await client.Bank.GetBankParamsAsync();
Console.WriteLine(bankparams.Result);

var spendableBalance = await client.Bank.GetBankSpendableBalancesByAddressAsync(address, null, null, null, null, null);
Console.WriteLine(spendableBalance.Result);

var supply = await client.Bank.GetBankSupplyAsync(null, null, null, null, null);
Console.WriteLine(supply.Result);

var denomSingle = await client.Bank.GetBankDenomByDenomAsync("token");
Console.WriteLine(denomSingle.Result);


