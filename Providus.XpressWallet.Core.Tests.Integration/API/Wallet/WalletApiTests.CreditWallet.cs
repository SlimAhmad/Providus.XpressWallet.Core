﻿using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Wallet
{
    public partial class WalletApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldCreditWalletAsync()
        {
            // given
            var request = new CreditWallet
            {
                Request = new CreditWalletRequest
                {
                     Metadata = new CreditWalletRequest.MetadataResponse
                     {
                         MoreData = "test",
                         SomeData = "test"
                     },
                     Amount = 100,
                     CustomerId = Guid.NewGuid().ToString(),
                     Reference = Guid.NewGuid().ToString()

                }
            };

            // when
            CreditWallet retrievedWalletModel =
              await this.xPressWalletClient.Wallet.CreditWalletAsync(request);

            // then
            Assert.NotNull(retrievedWalletModel);
        }
    }
}
