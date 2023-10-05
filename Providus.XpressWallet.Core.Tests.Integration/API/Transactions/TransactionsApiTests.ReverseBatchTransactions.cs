using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldReverseBatchTransactionAsync()
        {
            // given
            var request = new ReverseBatchTransaction
            {
                Request = new ReverseBatchTransactionRequest
                {
                   BatchReference = ""
                }
            };

            // when
            ReverseBatchTransaction retrievedTransactionModel =
              await this.xPressWalletClient.Transactions.ReverseBatchTransactionAsync(request);

            // then
            Assert.NotNull(retrievedTransactionModel);
        }
    }
}
