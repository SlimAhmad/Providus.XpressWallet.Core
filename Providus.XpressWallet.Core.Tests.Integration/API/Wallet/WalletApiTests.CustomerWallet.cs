using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Wallet
{
    public partial class WalletApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveCustomerWalletAsync()
        {
            // given
            string customerId = "183adcd3-4695-496a-8c25-10715cdfc45f";

            // when
            CustomerWallet retrievedWalletModel =
              await this.xPressWalletClient.Wallet.RetrieveCustomerWalletAsync(customerId);

            // then
            Assert.NotNull(retrievedWalletModel);
        }
    }
}
