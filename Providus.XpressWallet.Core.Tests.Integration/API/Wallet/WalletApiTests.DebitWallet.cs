using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Wallet
{
    public partial class WalletApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldDebitWalletAsync()
        {
            // given
            var request = new DebitWallet
            {
                Request = new DebitWalletRequest
                {
                    Amount = 100,
                    CustomerId = "183adcd3-4695-496a-8c25-10715cdfc45f",
                    Reference = Guid.NewGuid().ToString(),
                    Metadata = new DebitWalletRequest.MetadataResponse
                    {
                       SomeData = "test",
                       MoreData = "test"
                    }
                }
            };


            // when
            DebitWallet retrievedDebitWalletModel =
              await this.xPressWalletClient.Wallet.DebitWalletAsync(request);

            // then
            Assert.NotNull(retrievedDebitWalletModel);
        }
    }
}
