﻿using System.Collections;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CosmosApi.Test.Endpoints
{
    public class BankTests : BaseTest
    {
        public BankTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task AsyncGetBankBalanceByAddressNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);
            var balance =
                await client.Bank.GetBankBalancesByAddressAsync(Configuration.LocalAccount1Address, null, null, null, null, null);

            OutputHelper.WriteLine("Deserialized into");
            Dump(balance);

            Assert.NotEmpty((IEnumerable)balance);
            //All((IEnumerable)balance, CoinNotEmpty);
        }

        [Fact]
        public void SyncGetBankBalanceByAddressNotEmpty()
        {
            using var client = CreateClient(Configuration.LocalBaseUrl);
            var balance =
                client.Bank.GetBankBalancesByAddress(Configuration.LocalAccount1Address,null,null,null,null,null);

            OutputHelper.WriteLine("Deserialized into");
            Dump(balance);

            Assert.NotEmpty((IEnumerable)balance);
            //Assert.All(balance.Result.balance, CoinNotEmpty);
        }
    }
}