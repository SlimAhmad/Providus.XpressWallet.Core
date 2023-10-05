using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldDownloadCustomerTransactionAsync()
        {
            // given
            string customerId = "183adcd3-4695-496a-8c25-10715cdfc45f";

            // when
            DownloadCustomerTransaction retrievedTransactionModel =
              await this.xPressWalletClient.Transactions.DownloadCustomerTransactionAsync(customerId);

            // then
            Assert.NotNull(retrievedTransactionModel);
        }
    }
}
