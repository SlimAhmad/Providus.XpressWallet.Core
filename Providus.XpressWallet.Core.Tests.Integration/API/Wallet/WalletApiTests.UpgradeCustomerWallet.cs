using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Wallet
{
    public partial class WalletApiTests
    {
        [Fact]
        public async Task ShouldUpgradeCustomerWalletAsync()
        {
            // given
            var request = new UpgradeCustomerWallet
            {
                Request = new UpgradeCustomerWalletRequest
                {  
                     CustomerId = "dfa8e0b5-7eb0-4e63-b028-198ad59b2e70",
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
