using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveBatchTransactionsAsync()
        {
            // given
            string search = "";
            string category = "";
            string type = "ALL";
            int page = 1;
            int perPage = 3;


            // when
            BatchTransactions retrievedTransactionModel =
              await this.xPressWalletClient.Transactions.RetrieveBatchTransactionsAsync(search,category,type,page,perPage);

            // then
            Assert.NotNull(retrievedTransactionModel);
        }
    }
}
