using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldInitiateMerchantBankTransferAsync()
        {
            // given
            var request = new MerchantBankTransfer
            {
                Request = new MerchantBankTransferRequest
                {
                    AccountName = "AHMAD SALIM ABDULRAZZAK",
                    AccountNumber = "0812158322",
                    Amount = 50,
                    Narration = "test",
                    SortCode = "000014",
                    Metadata = new MerchantBankTransferRequest.MetadataResponse
                    {
                        CustomerData = "test"
                    }

                }
            };

            // when
            MerchantBankTransfer retrievedTransferModel =
              await this.xPressWalletClient.Transfers.MerchantBankTransferAsync(request);

            // then
            Assert.NotNull(retrievedTransferModel);
        }
    }
}
