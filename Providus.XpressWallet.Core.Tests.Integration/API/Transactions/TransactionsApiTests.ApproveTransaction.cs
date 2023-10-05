using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldApproveTransactionAsync()
        {
            // given
            var request = new ApproveTransaction
            {
                Request = new ApproveTransactionRequest
                {
                     TransactionId = "<>"
                }
            };

       
            // when
            ApproveTransaction retrievedTransactionModel =
              await this.xPressWalletClient.Transactions.ApproveTransactionAsync(request);

            // then
            Assert.NotNull(retrievedTransactionModel);
        }
    }
}
