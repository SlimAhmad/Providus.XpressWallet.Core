using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveTransactionDetailsAsync()
        {
            // given
            string transactionreference = "<>";

            // when
            TransactionDetails retrievedTransactionModel =
              await this.xPressWalletClient.Transactions.RetrieveTransactionDetailsAsync(transactionreference);

            // then
            Assert.NotNull(retrievedTransactionModel);
        }
    }
}
