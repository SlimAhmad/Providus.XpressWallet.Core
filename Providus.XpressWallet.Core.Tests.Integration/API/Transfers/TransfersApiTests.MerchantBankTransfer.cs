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
                    AccountName = "<>",
                    AccountNumber = "<>",
                    Amount = 50,
                    Narration = "<>",
                    SortCode = "<>",
                    Metadata = new MerchantBankTransferRequest.MetadataResponse
                    {
                        CustomerData = "<>"
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
