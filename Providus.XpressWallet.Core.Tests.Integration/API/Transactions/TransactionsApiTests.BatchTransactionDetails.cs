using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveBatchTransactionDetailsAsync()
        {
            // given
            string reference = "183adcd3-4695-496a-8c25-10715cdfc45f";

            // when
            BatchTransactionDetails retrievedTransactionModel =
              await this.xPressWalletClient.Transactions.RetrieveBatchTransactionDetailsAsync(reference);

            // then
            Assert.NotNull(retrievedTransactionModel);
        }
    }
}
