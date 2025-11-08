using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Wallet
{
    public partial class WalletApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldUpgradeCustomerWalletAsync()
        {
            // given
            var request = new UpgradeCustomerWallet
            {
                Request = new UpgradeCustomerWalletRequest
                {  
                     CustomerId = Guid.NewGuid().ToString(),
                     Tier = WalletTier.TIER_3
                }
            };

            // when
            UpgradeCustomerWallet retrievedWalletModel =
                await this.xPressWalletClient.Wallet.UpgradeCustomerWalletAsync(request);

            // then
            Assert.NotNull(retrievedWalletModel);
        }
    }
}
