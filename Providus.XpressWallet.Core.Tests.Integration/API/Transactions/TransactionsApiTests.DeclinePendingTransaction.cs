using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldDeclinePendingTransactionAsync()
        {
            // given
            string transactionId = "2348020245356";

            // when
            DeclinePendingTransaction retrievedTransactionModel =
              await this.xPressWalletClient.Transactions.DeclinePendingTransactionAsync(transactionId);

            // then
            Assert.NotNull(retrievedTransactionModel);
        }
    }
}
