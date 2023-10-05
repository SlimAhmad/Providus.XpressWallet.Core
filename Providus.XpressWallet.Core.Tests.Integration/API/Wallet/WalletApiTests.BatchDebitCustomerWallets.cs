using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Wallet
{
    public partial class WalletApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldBatchDebitCustomerWalletsAsync()
        {
            // given
            var request = new BatchDebitCustomerWallets
            {
                Request = new BatchDebitCustomerWalletsRequest
                {
                    BatchReference = Guid.NewGuid().ToString(),
                    Transactions = new List<BatchDebitCustomerWalletsRequest.Transaction> {
                         new BatchDebitCustomerWalletsRequest.Transaction
                         {
                            Amount = 100,
                            CustomerId = "e8a17512-0f30-4e82-a648-16540baf746e",
                            Reference = Guid.NewGuid().ToString(),
                         }
                     }
                }
            };


            // when
            BatchDebitCustomerWallets retrievedWalletModel =
              await this.xPressWalletClient.Wallet.BatchDebitCustomerWalletsAsync(request);

            // then
            Assert.NotNull(retrievedWalletModel);
        }
    }
}
