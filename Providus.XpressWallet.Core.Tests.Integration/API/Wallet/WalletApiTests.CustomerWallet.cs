using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Wallet
{
    public partial class WalletApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveCustomerWalletAsync()
        {
            // given
            string customerId = "e8a17512-0f30-4e82-a648-16540baf746e";


            // when
            CustomerWallet retrievedWalletModel =
              await this.xPressWalletClient.Wallet.RetrieveCustomerWalletAsync(customerId);

            // then
            Assert.NotNull(retrievedWalletModel);
        }
    }
}
