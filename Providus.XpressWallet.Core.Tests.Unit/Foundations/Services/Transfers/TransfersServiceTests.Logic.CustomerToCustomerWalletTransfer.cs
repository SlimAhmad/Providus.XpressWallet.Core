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
        public async Task ShouldPostCustomerToCustomerWalletTransferWithCustomerToCustomerWalletTransferRequestAsync()
        {
            // given 



            dynamic createRandomCustomerToCustomerWalletTransferRequestProperties =
              CreateRandomCustomerToCustomerWalletTransferRequestProperties();

            dynamic createRandomCustomerToCustomerWalletTransferResponseProperties =
                CreateRandomCustomerToCustomerWalletTransferResponseProperties();


            var randomExternalCustomerToCustomerWalletTransferRequest = new ExternalCustomerToCustomerWalletTransferRequest
            {
                ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
                FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
                Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,

            };

            var randomExternalCustomerToCustomerWalletTransferResponse = new ExternalCustomerToCustomerWalletTransferResponse
            {
              Data = new ExternalCustomerToCustomerWalletTransferResponse.ExternalData
              {
                 Amount = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.Amount,
                 Description = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.Description,
                 Reference = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.Reference,
                 SourceCustomerId = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.SourceCustomerId,
                 SourceCustomerWallet = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.SourceCustomerWallet,
                 TargetCustomerId = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.TargetCustomerId,
                 TargetCustomerWallet = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.TargetCustomerWallet,
                 Total = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.Total,
                 TransactionFee = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.TransactionFee
              },
              Message = createRandomCustomerToCustomerWalletTransferResponseProperties.Message,
              Status = createRandomCustomerToCustomerWalletTransferResponseProperties.Status
                   
            };


            var randomCustomerToCustomerWalletTransferRequest = new CustomerToCustomerWalletTransferRequest
            {
                ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
                FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
                Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,

            };

            var randomCustomerToCustomerWalletTransferResponse = new CustomerToCustomerWalletTransferResponse
            {
                Data = new CustomerToCustomerWalletTransferResponse.DataResponse
                {
                    Amount = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.Amount,
                    Description = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.Description,
                    Reference = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.Reference,
                    SourceCustomerId = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.SourceCustomerId,
                    SourceCustomerWallet = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.SourceCustomerWallet,
                    TargetCustomerId = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.TargetCustomerId,
                    TargetCustomerWallet = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.TargetCustomerWallet,
                    Total = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.Total,
                    TransactionFee = createRandomCustomerToCustomerWalletTransferResponseProperties.Data.TransactionFee
                },
                Message = createRandomCustomerToCustomerWalletTransferResponseProperties.Message,
                Status = createRandomCustomerToCustomerWalletTransferResponseProperties.Status
            };


            var randomCustomerToCustomerWalletTransfer = new CustomerToCustomerWalletTransfer
            {
                Request = randomCustomerToCustomerWalletTransferRequest,
            };

            CustomerToCustomerWalletTransfer inputCustomerToCustomerWalletTransfer = randomCustomerToCustomerWalletTransfer;
            CustomerToCustomerWalletTransfer expectedCustomerToCustomerWalletTransfer = inputCustomerToCustomerWalletTransfer.DeepClone();
            expectedCustomerToCustomerWalletTransfer.Response = randomCustomerToCustomerWalletTransferResponse;

            ExternalCustomerToCustomerWalletTransferRequest mappedExternalCustomerToCustomerWalletTransferRequest =
               randomExternalCustomerToCustomerWalletTransferRequest;

            ExternalCustomerToCustomerWalletTransferResponse returnedExternalCustomerToCustomerWalletTransferResponse =
                randomExternalCustomerToCustomerWalletTransferResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCustomerToCustomerWalletTransferAsync(It.Is(
                      SameExternalCustomerToCustomerWalletTransferRequestAs(mappedExternalCustomerToCustomerWalletTransferRequest))))
                     .ReturnsAsync(returnedExternalCustomerToCustomerWalletTransferResponse);

            // when
            CustomerToCustomerWalletTransfer actualCreateCustomerToCustomerWalletTransfer =
               await this.transfersService.PostCustomerToCustomerWalletTransferRequestAsync(inputCustomerToCustomerWalletTransfer);

            // then
            actualCreateCustomerToCustomerWalletTransfer.Should().BeEquivalentTo(expectedCustomerToCustomerWalletTransfer);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostCustomerToCustomerWalletTransferAsync(It.Is(
                   SameExternalCustomerToCustomerWalletTransferRequestAs(mappedExternalCustomerToCustomerWalletTransferRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
