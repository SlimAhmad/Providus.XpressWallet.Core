using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact]
        public async Task ShouldRetrieveBankListAsync()
        {
            // given

            // when
            BankList retrievedTransferModel =
              await this.xPressWalletClient.Transfers.RetrieveBankListAsync();

            // then
            Assert.NotNull(retrievedTransferModel);
        }
    }
}
