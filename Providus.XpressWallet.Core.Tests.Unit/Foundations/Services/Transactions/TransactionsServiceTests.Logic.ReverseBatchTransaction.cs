using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {
        [Fact]
        public async Task ShouldPostReverseBatchTransactionWithReverseBatchTransactionRequestAsync()
        {
            // given 



            dynamic createRandomReverseBatchTransactionRequestProperties =
              CreateRandomReverseBatchTransactionRequestProperties();

            dynamic createRandomReverseBatchTransactionResponseProperties =
                CreateRandomReverseBatchTransactionResponseProperties();


            var randomExternalReverseBatchTransactionRequest = new ExternalReverseBatchTransactionRequest
            {

                BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,


            };

            var randomExternalReverseBatchTransactionResponse = new ExternalReverseBatchTransactionResponse
            {
                
                Message = createRandomReverseBatchTransactionResponseProperties.Message,
                Status = createRandomReverseBatchTransactionResponseProperties.Status
                   
            };


            var randomReverseBatchTransactionRequest = new ReverseBatchTransactionRequest
            {
                
               BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,
               

            };

            var randomReverseBatchTransactionResponse = new ReverseBatchTransactionResponse
            {
              
                Message = createRandomReverseBatchTransactionResponseProperties.Message,
                Status = createRandomReverseBatchTransactionResponseProperties.Status
            };


            var randomReverseBatchTransaction = new ReverseBatchTransaction
            {
                Request = randomReverseBatchTransactionRequest,
            };

           

            ReverseBatchTransaction inputReverseBatchTransaction = randomReverseBatchTransaction;
            ReverseBatchTransaction expectedReverseBatchTransaction = inputReverseBatchTransaction.DeepClone();
            expectedReverseBatchTransaction.Response = randomReverseBatchTransactionResponse;

            ExternalReverseBatchTransactionRequest mappedExternalReverseBatchTransactionRequest =
               randomExternalReverseBatchTransactionRequest;

            ExternalReverseBatchTransactionResponse returnedExternalReverseBatchTransactionResponse =
                randomExternalReverseBatchTransactionResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostReverseBatchTransactionAsync(It.Is(
                      SameExternalReverseBatchTransactionRequestAs(mappedExternalReverseBatchTransactionRequest))))
                     .ReturnsAsync(returnedExternalReverseBatchTransactionResponse);

            // when
            ReverseBatchTransaction actualCreateReverseBatchTransaction =
               await this.transactionsService.PostReverseBatchTransactionRequestAsync(inputReverseBatchTransaction);

            // then
            actualCreateReverseBatchTransaction.Should().BeEquivalentTo(expectedReverseBatchTransaction);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostReverseBatchTransactionAsync(It.Is(
                   SameExternalReverseBatchTransactionRequestAs(mappedExternalReverseBatchTransactionRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
