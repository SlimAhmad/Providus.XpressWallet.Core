using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveCustomerTransactionAsync()
        {
            // given
            string customerId = "<>";
            string type = "<ALL,CREDIT,DEBIT>";
            int page = 1;
            int perPage = 3;

            // when
            CustomerTransactions retrievedTransactionModel =
              await this.xPressWalletClient.Transactions.RetrieveCustomerTransactionAsync(customerId,page,type,perPage);

            // then
            Assert.NotNull(retrievedTransactionModel);
        }
    }
}
