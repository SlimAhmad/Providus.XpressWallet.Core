using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {
        [Fact]
        public async Task ShouldPostTransactionDetailsWithTransactionDetailsRequestAsync()
        {
            // given 
            var inputTransactionReference = GetRandomString();
           

            dynamic createRandomTransactionDetailsResponseProperties =
                CreateRandomTransactionDetailsResponseProperties();



            var randomExternalTransactionDetailsResponse = new ExternalTransactionDetailsResponse
            {
                    
                Transaction = new ExternalTransactionDetailsResponse.ExternalTransaction
                {
                  Amount = createRandomTransactionDetailsResponseProperties.Transaction.Amount,
                  BalanceAfter = createRandomTransactionDetailsResponseProperties.Transaction.BalanceAfter,
                  BalanceBefore = createRandomTransactionDetailsResponseProperties.Transaction.BalanceBefore,
                  Category = createRandomTransactionDetailsResponseProperties.Transaction.Category,
                  Completed = createRandomTransactionDetailsResponseProperties.Transaction.Completed,
                  CreatedAt = createRandomTransactionDetailsResponseProperties.Transaction.CreatedAt,
                  Currency = createRandomTransactionDetailsResponseProperties.Transaction.Currency,
                  Description = createRandomTransactionDetailsResponseProperties.Transaction.Description,
                  Destination = createRandomTransactionDetailsResponseProperties.Transaction.Destination,
                  Id = createRandomTransactionDetailsResponseProperties.Transaction.Id,
                  Metadata = createRandomTransactionDetailsResponseProperties.Transaction.Metadata,
                  Reference = createRandomTransactionDetailsResponseProperties.Transaction.Reference,
                  Source = createRandomTransactionDetailsResponseProperties.Transaction.Source,
                  Type = createRandomTransactionDetailsResponseProperties.Transaction.Type,
                  UpdatedAt = createRandomTransactionDetailsResponseProperties.Transaction.UpdatedAt,
                },
                Status = createRandomTransactionDetailsResponseProperties.Status
                   
            };


   
            var randomTransactionDetailsResponse = new TransactionDetailsResponse
            {

                Transaction = new TransactionDetailsResponse.TransactionResponse
                {
                    Amount = createRandomTransactionDetailsResponseProperties.Transaction.Amount,
                    BalanceAfter = createRandomTransactionDetailsResponseProperties.Transaction.BalanceAfter,
                    BalanceBefore = createRandomTransactionDetailsResponseProperties.Transaction.BalanceBefore,
                    Category = createRandomTransactionDetailsResponseProperties.Transaction.Category,
                    Completed = createRandomTransactionDetailsResponseProperties.Transaction.Completed,
                    CreatedAt = createRandomTransactionDetailsResponseProperties.Transaction.CreatedAt,
                    Currency = createRandomTransactionDetailsResponseProperties.Transaction.Currency,
                    Description = createRandomTransactionDetailsResponseProperties.Transaction.Description,
                    Destination = createRandomTransactionDetailsResponseProperties.Transaction.Destination,
                    Id = createRandomTransactionDetailsResponseProperties.Transaction.Id,
                    Metadata = createRandomTransactionDetailsResponseProperties.Transaction.Metadata,
                    Reference = createRandomTransactionDetailsResponseProperties.Transaction.Reference,
                    Source = createRandomTransactionDetailsResponseProperties.Transaction.Source,
                    Type = createRandomTransactionDetailsResponseProperties.Transaction.Type,
                    UpdatedAt = createRandomTransactionDetailsResponseProperties.Transaction.UpdatedAt,
                },
                Status = createRandomTransactionDetailsResponseProperties.Status

            };



            var expectedResponse = new TransactionDetails
            {
                Response = randomTransactionDetailsResponse
            };

           

            ExternalTransactionDetailsResponse returnedExternalTransactionDetailsResponse =
                randomExternalTransactionDetailsResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetTransactionDetailsAsync(inputTransactionReference))
                     .ReturnsAsync(returnedExternalTransactionDetailsResponse);

            // when
            TransactionDetails actualCreateTransactionDetails =
               await this.transactionsService.GetTransactionDetailsRequestAsync(inputTransactionReference);

            // then
            actualCreateTransactionDetails.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetTransactionDetailsAsync(inputTransactionReference),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
