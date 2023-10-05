using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrievePendingTransactionsAsync()
        {
            // given

            string type = "ALL";
            int page = 1;

            // when
            PendingTransaction retrievedTransactionModel =
              await this.xPressWalletClient.Transactions.RetrievePendingTransactionsAsync(page,type);

            // then
            Assert.NotNull(retrievedTransactionModel);
        }
    }
}
