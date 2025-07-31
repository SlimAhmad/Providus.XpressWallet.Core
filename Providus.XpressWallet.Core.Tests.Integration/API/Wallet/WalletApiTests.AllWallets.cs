using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Wallet
{
    public partial class WalletApiTests
    {
        [Fact]
        public async Task ShouldRetrieveAllWalletsAsync()
        {
            // given

            // when
            AllWallets retrievedWalletModel =
              await this.xPressWalletClient.Wallet.RetrieveAllWalletsAsync();

            // then
            Assert.NotNull(retrievedWalletModel);
        }
    }
}
