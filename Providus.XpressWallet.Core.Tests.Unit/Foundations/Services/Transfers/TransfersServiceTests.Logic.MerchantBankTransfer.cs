using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldPostMerchantBankTransferWithMerchantBankTransferRequestAsync()
        {
            // given 



            dynamic createRandomMerchantBankTransferRequestProperties =
              CreateRandomMerchantBankTransferRequestProperties();

            dynamic createRandomMerchantBankTransferResponseProperties =
                CreateRandomMerchantBankTransferResponseProperties();


            var randomExternalMerchantBankTransferRequest = new ExternalMerchantBankTransferRequest
            {
                AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalMerchantBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                Amount = createRandomMerchantBankTransferRequestProperties.Amount,

            };

            var randomExternalMerchantBankTransferResponse = new ExternalMerchantBankTransferResponse
            {
              Transfer = new ExternalMerchantBankTransferResponse.ExternalTransfer
              {
                 Metadata = new ExternalMerchantBankTransferResponse.Metadata
                 {
                    CustomerData = createRandomMerchantBankTransferResponseProperties.Transfer.Metadata.CustomerData,
                   
                 },
                 Amount = createRandomMerchantBankTransferResponseProperties.Transfer.Amount,
                 Charges = createRandomMerchantBankTransferResponseProperties.Transfer.Charges,
                 Description = createRandomMerchantBankTransferResponseProperties.Transfer.Description,
                 Destination = createRandomMerchantBankTransferResponseProperties.Transfer.Destination,
                 Reference = createRandomMerchantBankTransferResponseProperties.Transfer.Reference,
                 SessionId = createRandomMerchantBankTransferResponseProperties.Transfer.SessionId,
                 Total = createRandomMerchantBankTransferResponseProperties.Transfer.Total,
                 TransactionReference = createRandomMerchantBankTransferResponseProperties.Transfer.TransactionReference,
                 Vat = createRandomMerchantBankTransferResponseProperties.Transfer.Vat
              },
              
              Message = createRandomMerchantBankTransferResponseProperties.Message,
              Status = createRandomMerchantBankTransferResponseProperties.Status
                   
            };


            var randomMerchantBankTransferRequest = new MerchantBankTransferRequest
            {
                AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                Metadata = new MerchantBankTransferRequest.MetadataResponse
                {
                    CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                Amount = createRandomMerchantBankTransferRequestProperties.Amount,

            };

            var randomMerchantBankTransferResponse = new MerchantBankTransferResponse
            {
                Transfer = new MerchantBankTransferResponse.TransferResponse
                {
                    Metadata = new MerchantBankTransferResponse.Metadata
                    {
                        CustomerData = createRandomMerchantBankTransferResponseProperties.Transfer.Metadata.CustomerData,

                    },
                    Amount = createRandomMerchantBankTransferResponseProperties.Transfer.Amount,
                    Charges = createRandomMerchantBankTransferResponseProperties.Transfer.Charges,
                    Description = createRandomMerchantBankTransferResponseProperties.Transfer.Description,
                    Destination = createRandomMerchantBankTransferResponseProperties.Transfer.Destination,
                    Reference = createRandomMerchantBankTransferResponseProperties.Transfer.Reference,
                    SessionId = createRandomMerchantBankTransferResponseProperties.Transfer.SessionId,
                    Total = createRandomMerchantBankTransferResponseProperties.Transfer.Total,
                    TransactionReference = createRandomMerchantBankTransferResponseProperties.Transfer.TransactionReference,
                    Vat = createRandomMerchantBankTransferResponseProperties.Transfer.Vat
                },

                Message = createRandomMerchantBankTransferResponseProperties.Message,
                Status = createRandomMerchantBankTransferResponseProperties.Status
            };


            var randomMerchantBankTransfer = new MerchantBankTransfer
            {
                Request = randomMerchantBankTransferRequest,
            };

            MerchantBankTransfer inputMerchantBankTransfer = randomMerchantBankTransfer;
            MerchantBankTransfer expectedMerchantBankTransfer = inputMerchantBankTransfer.DeepClone();
            expectedMerchantBankTransfer.Response = randomMerchantBankTransferResponse;

            ExternalMerchantBankTransferRequest mappedExternalMerchantBankTransferRequest =
               randomExternalMerchantBankTransferRequest;

            ExternalMerchantBankTransferResponse returnedExternalMerchantBankTransferResponse =
                randomExternalMerchantBankTransferResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostMerchantBankTransferAsync(It.Is(
                      SameExternalMerchantBankTransferRequestAs(mappedExternalMerchantBankTransferRequest))))
                     .ReturnsAsync(returnedExternalMerchantBankTransferResponse);

            // when
            MerchantBankTransfer actualCreateMerchantBankTransfer =
               await this.transfersService.PostMerchantBankTransferRequestAsync(inputMerchantBankTransfer);

            // then
            actualCreateMerchantBankTransfer.Should().BeEquivalentTo(expectedMerchantBankTransfer);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostMerchantBankTransferAsync(It.Is(
                   SameExternalMerchantBankTransferRequestAs(mappedExternalMerchantBankTransferRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
