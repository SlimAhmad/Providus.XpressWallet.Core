using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveMerchantTransactionsAsync()
        {
            // given
            string status = "";
            string type = "ALL";
            int page = 1;

            // when
            MerchantTransactions retrievedTransactionModel =
              await this.xPressWalletClient.Transactions.RetrieveMerchantTransactionsAsync(page,type,status);

            // then
            Assert.NotNull(retrievedTransactionModel);
        }
    }
}
