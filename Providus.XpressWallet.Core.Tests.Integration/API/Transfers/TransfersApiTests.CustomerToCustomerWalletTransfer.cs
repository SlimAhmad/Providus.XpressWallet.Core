using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldInitiateCustomerToCustomerWalletTransferAsync()
        {
            // given
            var request = new CustomerToCustomerWalletTransfer
            {
                Request = new CustomerToCustomerWalletTransferRequest
                {
                    Amount = 50,
                    FromCustomerId = "183adcd3-4695-496a-8c25-10715cdfc45f",
                    ToCustomerId = "e8a17512-0f30-4e82-a648-16540baf746e"
                }
            };


            // when
            CustomerToCustomerWalletTransfer retrievedTransferModel =
              await this.xPressWalletClient.Transfers.CustomerToCustomerWalletTransferAsync(request);

            // then
            Assert.NotNull(retrievedTransferModel);
        }
    }
}
