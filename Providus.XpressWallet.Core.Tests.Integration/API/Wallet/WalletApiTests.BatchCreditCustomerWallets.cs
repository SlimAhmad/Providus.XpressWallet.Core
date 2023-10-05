using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Wallet
{
    public partial class WalletApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldBatchCreditCustomerWalletsAsync()
        {
            // given
            var request = new BatchCreditCustomerWallets
            {
                Request = new BatchCreditCustomerWalletsRequest
                {
                     BatchReference = "TESTBatchDebit@energywallet",
                     Transactions = new List<BatchCreditCustomerWalletsRequest.Transaction> {
                         new BatchCreditCustomerWalletsRequest.Transaction 
                         {
                            Amount = 50,
                            CustomerId = "e8a17512-0f30-4e82-a648-16540baf746e"
                         }
                     }
                }
            };


            // when
            BatchCreditCustomerWallets retrievedWalletModel =
              await this.xPressWalletClient.Wallet.BatchCreditCustomerWalletsAsync(request);

            // then
            Assert.NotNull(retrievedWalletModel);
        }
    }
}
