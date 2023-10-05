using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveDownloadMerchantTransactionAsync()
        {
            // given


            // when
            DownloadMerchantTransaction retrievedTransactionModel =
              await this.xPressWalletClient.Transactions.DownloadMerchantTransactionAsync();

            // then
            Assert.NotNull(retrievedTransactionModel);
        }
    }
}
