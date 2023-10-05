using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;

namespace Providus.XpressWallet.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveMerchantBatchBankTransferAsync()
        {
            // given
            var request = new MerchantBatchBankTransfer
            {
               Request = new List<MerchantBatchBankTransferRequest>
               {
                 new MerchantBatchBankTransferRequest
                 {
                        AccountName = "<>",
                        AccountNumber = "<>",
                        Amount = 50,
                        Narration = "test",
                        SortCode = "000014",
                        Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                        {
                            CustomerData = "test"
                        }
                 }
               }
            };


            // when
            MerchantBatchBankTransfer retrievedTransferModel =
              await this.xPressWalletClient.Transfers.MerchantBatchBankTransferAsync(request);

            // then
            Assert.NotNull(retrievedTransferModel);
        }
    }
}
