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
        public async Task ShouldPostCustomerBankTransferWithCustomerBankTransferRequestAsync()
        {
            // given 



            dynamic createRandomCustomerBankTransferRequestProperties =
              CreateRandomCustomerBankTransferRequestProperties();

            dynamic createRandomCustomerBankTransferResponseProperties =
                CreateRandomCustomerBankTransferResponseProperties();


            var randomExternalCustomerBankTransferRequest = new ExternalCustomerBankTransferRequest
            {
                AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalCustomerBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,

            };

            var randomExternalCustomerBankTransferResponse = new ExternalCustomerBankTransferResponse
            {
              Transfer = new ExternalCustomerBankTransferResponse.ExternalTransfer
              {
                 Metadata = new ExternalCustomerBankTransferResponse.Metadata
                 {
                    CustomerData = createRandomCustomerBankTransferResponseProperties.Transfer.Metadata.CustomerData,
                   
                 },
                 
                 Amount = createRandomCustomerBankTransferResponseProperties.Transfer.Amount,
                 Charges = createRandomCustomerBankTransferResponseProperties.Transfer.Charges,
                 Description = createRandomCustomerBankTransferResponseProperties.Transfer.Description,
                 Destination = createRandomCustomerBankTransferResponseProperties.Transfer.Destination,
                 Reference = createRandomCustomerBankTransferResponseProperties.Transfer.Reference,
                 SessionId = createRandomCustomerBankTransferResponseProperties.Transfer.SessionId,
                 Total = createRandomCustomerBankTransferResponseProperties.Transfer.Total,
                 TransactionReference = createRandomCustomerBankTransferResponseProperties.Transfer.TransactionReference,
                 Vat = createRandomCustomerBankTransferResponseProperties.Transfer.Vat
               
              },
              
              Message = createRandomCustomerBankTransferResponseProperties.Message,
              Status = createRandomCustomerBankTransferResponseProperties.Status
                   
            };


            var randomCustomerBankTransferRequest = new CustomerBankTransferRequest
            {
                AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                Metadata = new CustomerBankTransferRequest.MetadataResponse
                {
                    CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,

            };

            var randomCustomerBankTransferResponse = new CustomerBankTransferResponse
            {
                Transfer = new CustomerBankTransferResponse.TransferResponse
                {
                    Metadata = new CustomerBankTransferResponse.Metadata
                    {
                        CustomerData = createRandomCustomerBankTransferResponseProperties.Transfer.Metadata.CustomerData,

                    },
                    Amount = createRandomCustomerBankTransferResponseProperties.Transfer.Amount,
                    Charges = createRandomCustomerBankTransferResponseProperties.Transfer.Charges,
                    Description = createRandomCustomerBankTransferResponseProperties.Transfer.Description,
                    Destination = createRandomCustomerBankTransferResponseProperties.Transfer.Destination,
                    Reference = createRandomCustomerBankTransferResponseProperties.Transfer.Reference,
                    SessionId = createRandomCustomerBankTransferResponseProperties.Transfer.SessionId,
                    Total = createRandomCustomerBankTransferResponseProperties.Transfer.Total,
                    TransactionReference = createRandomCustomerBankTransferResponseProperties.Transfer.TransactionReference,
                    Vat = createRandomCustomerBankTransferResponseProperties.Transfer.Vat
                },

                Message = createRandomCustomerBankTransferResponseProperties.Message,
                Status = createRandomCustomerBankTransferResponseProperties.Status
            };


            var randomCustomerBankTransfer = new CustomerBankTransfer
            {
                Request = randomCustomerBankTransferRequest,
            };

            CustomerBankTransfer inputCustomerBankTransfer = randomCustomerBankTransfer;
            CustomerBankTransfer expectedCustomerBankTransfer = inputCustomerBankTransfer.DeepClone();
            expectedCustomerBankTransfer.Response = randomCustomerBankTransferResponse;

            ExternalCustomerBankTransferRequest mappedExternalCustomerBankTransferRequest =
               randomExternalCustomerBankTransferRequest;

            ExternalCustomerBankTransferResponse returnedExternalCustomerBankTransferResponse =
                randomExternalCustomerBankTransferResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCustomerBankTransferAsync(It.Is(
                      SameExternalCustomerBankTransferRequestAs(mappedExternalCustomerBankTransferRequest))))
                     .ReturnsAsync(returnedExternalCustomerBankTransferResponse);

            // when
            CustomerBankTransfer actualCreateCustomerBankTransfer =
               await this.transfersService.PostCustomerBankTransferRequestAsync(inputCustomerBankTransfer);

            // then
            actualCreateCustomerBankTransfer.Should().BeEquivalentTo(expectedCustomerBankTransfer);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostCustomerBankTransferAsync(It.Is(
                   SameExternalCustomerBankTransferRequestAs(mappedExternalCustomerBankTransferRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
