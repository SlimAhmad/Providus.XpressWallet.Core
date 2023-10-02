using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {
        [Fact]
        public async Task ShouldPostDeclinePendingTransactionWithDeclinePendingTransactionRequestAsync()
        {
            // given 
            var inputTransctionId = GetRandomString();
          

            dynamic createRandomDeclinePendingTransactionResponseProperties =
                CreateRandomDeclinePendingTransactionResponseProperties();



            var randomExternalDeclinePendingTransactionResponse = new ExternalDeclinePendingTransactionResponse
            {
                    
                Message = createRandomDeclinePendingTransactionResponseProperties.Message,
                Status = createRandomDeclinePendingTransactionResponseProperties.Status
                   
            };


   
            var randomDeclinePendingTransactionResponse = new DeclinePendingTransactionResponse
            {
                Message = createRandomDeclinePendingTransactionResponseProperties.Message,
                Status = createRandomDeclinePendingTransactionResponseProperties.Status


            };



            var expectedResponse = new DeclinePendingTransaction
            {
                Response = randomDeclinePendingTransactionResponse
            };

           

            ExternalDeclinePendingTransactionResponse returnedExternalDeclinePendingTransactionResponse =
                randomExternalDeclinePendingTransactionResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.DeleteDeclinePendingTransactionAsync(inputTransctionId))
                     .ReturnsAsync(returnedExternalDeclinePendingTransactionResponse);

            // when
            DeclinePendingTransaction actualCreateDeclinePendingTransaction =
               await this.transactionsService.DeleteDeclinePendingTransactionRequestAsync(inputTransctionId);

            // then
            actualCreateDeclinePendingTransaction.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.DeleteDeclinePendingTransactionAsync(inputTransctionId),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
