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
        public async Task ShouldPostApproveTransactionWithApproveTransactionRequestAsync()
        {
            // given 



            dynamic createRandomApproveTransactionRequestProperties =
              CreateRandomApproveTransactionRequestProperties();

            dynamic createRandomApproveTransactionResponseProperties =
                CreateRandomApproveTransactionResponseProperties();


            var randomExternalApproveTransactionRequest = new ExternalApproveTransactionRequest
            {

                TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,


            };

            var randomExternalApproveTransactionResponse = new ExternalApproveTransactionResponse
            {
                
                Message = createRandomApproveTransactionResponseProperties.Message,
                Status = createRandomApproveTransactionResponseProperties.Status
                   
            };


            var randomApproveTransactionRequest = new ApproveTransactionRequest
            {
                
               TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,
               

            };

            var randomApproveTransactionResponse = new ApproveTransactionResponse
            {
              
                Message = createRandomApproveTransactionResponseProperties.Message,
                Status = createRandomApproveTransactionResponseProperties.Status
            };


            var randomApproveTransaction = new ApproveTransaction
            {
                Request = randomApproveTransactionRequest,
            };

           

            ApproveTransaction inputApproveTransaction = randomApproveTransaction;
            ApproveTransaction expectedApproveTransaction = inputApproveTransaction.DeepClone();
            expectedApproveTransaction.Response = randomApproveTransactionResponse;

            ExternalApproveTransactionRequest mappedExternalApproveTransactionRequest =
               randomExternalApproveTransactionRequest;

            ExternalApproveTransactionResponse returnedExternalApproveTransactionResponse =
                randomExternalApproveTransactionResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostApproveTransactionAsync(It.Is(
                      SameExternalApproveTransactionRequestAs(mappedExternalApproveTransactionRequest))))
                     .ReturnsAsync(returnedExternalApproveTransactionResponse);

            // when
            ApproveTransaction actualCreateApproveTransaction =
               await this.transactionsService.PostApproveTransactionRequestAsync(inputApproveTransaction);

            // then
            actualCreateApproveTransaction.Should().BeEquivalentTo(expectedApproveTransaction);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostApproveTransactionAsync(It.Is(
                   SameExternalApproveTransactionRequestAs(mappedExternalApproveTransactionRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
