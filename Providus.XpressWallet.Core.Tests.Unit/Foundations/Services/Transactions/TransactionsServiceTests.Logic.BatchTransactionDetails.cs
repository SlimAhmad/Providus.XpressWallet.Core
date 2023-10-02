using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {
        [Fact]
        public async Task ShouldPostBatchTransactionDetailsWithBatchTransactionDetailsRequestAsync()
        {
            // given 
            var inputReference = GetRandomString();
            

            dynamic createRandomBatchTransactionDetailsResponseProperties =
                CreateRandomBatchTransactionDetailsResponseProperties();



            var randomExternalBatchTransactionDetailsResponse = new ExternalBatchTransactionDetailsResponse
            {
                    
                Data = new ExternalBatchTransactionDetailsResponse.ExternalData
                {
                  AllReferences = createRandomBatchTransactionDetailsResponseProperties.Data.AllReferences,
                  CreatedAt = createRandomBatchTransactionDetailsResponseProperties.Data.CreatedAt,
                  FailedReferences = createRandomBatchTransactionDetailsResponseProperties.Data.FailedReferences,
                  Id = createRandomBatchTransactionDetailsResponseProperties.Data.Id,
                  PassedReferences = createRandomBatchTransactionDetailsResponseProperties.Data.PassedReferences,
                  Reference = createRandomBatchTransactionDetailsResponseProperties.Data.Reference,
                  Source = new ExternalBatchTransactionDetailsResponse.Source
                  {
                     Type = createRandomBatchTransactionDetailsResponseProperties.Data.Source.Type,
                     UserId = createRandomBatchTransactionDetailsResponseProperties.Data.Source.UserId,
                     WalletId = createRandomBatchTransactionDetailsResponseProperties.Data.Source.WalletId
                  },
                  Reversed = createRandomBatchTransactionDetailsResponseProperties.Data.Reversed,
                  Type = createRandomBatchTransactionDetailsResponseProperties.Data.Type,
                  UpdatedAt = createRandomBatchTransactionDetailsResponseProperties.Data.UpdatedAt
                },
                Status = createRandomBatchTransactionDetailsResponseProperties.Status
                   
            };


   
            var randomBatchTransactionDetailsResponse = new BatchTransactionDetailsResponse
            {
                Data = new BatchTransactionDetailsResponse.DataResponse
                {
                    AllReferences = createRandomBatchTransactionDetailsResponseProperties.Data.AllReferences,
                    CreatedAt = createRandomBatchTransactionDetailsResponseProperties.Data.CreatedAt,
                    FailedReferences = createRandomBatchTransactionDetailsResponseProperties.Data.FailedReferences,
                    Id = createRandomBatchTransactionDetailsResponseProperties.Data.Id,
                    PassedReferences = createRandomBatchTransactionDetailsResponseProperties.Data.PassedReferences,
                    Reference = createRandomBatchTransactionDetailsResponseProperties.Data.Reference,
                    Source = new BatchTransactionDetailsResponse.Source
                    {
                        Type = createRandomBatchTransactionDetailsResponseProperties.Data.Source.Type,
                        UserId = createRandomBatchTransactionDetailsResponseProperties.Data.Source.UserId,
                        WalletId = createRandomBatchTransactionDetailsResponseProperties.Data.Source.WalletId
                    },
                    Reversed = createRandomBatchTransactionDetailsResponseProperties.Data.Reversed,
                    Type = createRandomBatchTransactionDetailsResponseProperties.Data.Type,
                    UpdatedAt = createRandomBatchTransactionDetailsResponseProperties.Data.UpdatedAt
                },
                Status = createRandomBatchTransactionDetailsResponseProperties.Status

            };



            var expectedResponse = new BatchTransactionDetails
            {
                Response = randomBatchTransactionDetailsResponse
            };

           

            ExternalBatchTransactionDetailsResponse returnedExternalBatchTransactionDetailsResponse =
                randomExternalBatchTransactionDetailsResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBatchTransactionDetailsAsync(inputReference))
                     .ReturnsAsync(returnedExternalBatchTransactionDetailsResponse);

            // when
            BatchTransactionDetails actualCreateBatchTransactionDetails =
               await this.transactionsService.GetBatchTransactionDetailsRequestAsync(inputReference);

            // then
            actualCreateBatchTransactionDetails.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetBatchTransactionDetailsAsync(inputReference),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
