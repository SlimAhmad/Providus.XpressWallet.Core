using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Wallet
{
    public partial class WalletApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldFundMerchantSandBoxWalletAsync()
        {
            // given
            var request = new FundMerchantSandBoxWallet
            {
                Request = new FundMerchantSandBoxWalletRequest
                {
                    Amount = 100,
                    
                }
            };


            // when
            FundMerchantSandBoxWallet retrievedWalletModel =
              await this.xPressWalletClient.Wallet.FundMerchantSandBoxWalletAsync(request);

            // then
            Assert.NotNull(retrievedWalletModel);
        }
    }
}
