using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldInitiateCustomerBankTransferAsync()
        {
            // given
            var request = new CustomerBankTransfer
            {
                Request = new CustomerBankTransferRequest
                {
                     AccountName = "Energywallet Services LTD",
                     AccountNumber = "8866159722",
                     Amount = 50,
                     CustomerId = "183adcd3-4695-496a-8c25-10715cdfc45f",
                     Narration = "test",
                     SortCode = "000014",
                     Metadata = new CustomerBankTransferRequest.MetadataResponse
                     {
                         CustomerData = "test"
                     }
                }
            };

            // when
            CustomerBankTransfer retrievedTransferModel =
              await this.xPressWalletClient.Transfers.CustomerBankTransferAsync(request);

            // then
            Assert.NotNull(retrievedTransferModel);
        }
    }
}
