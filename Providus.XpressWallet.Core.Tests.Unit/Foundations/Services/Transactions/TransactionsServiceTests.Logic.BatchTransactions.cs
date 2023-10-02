using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {
        [Fact]
        public async Task ShouldPostBatchTransactionsWithBatchTransactionsRequestAsync()
        {
            // given 
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputSearch = GetRandomString();
            var inputCategory = GetRandomString();

            dynamic createRandomBatchTransactionsResponseProperties =
                CreateRandomBatchTransactionsResponseProperties();



            var randomExternalBatchTransactionsResponse = new ExternalBatchTransactionsResponse
            {
                    
                 Metadata = new ExternalBatchTransactionsResponse.ExternalMetadata
                 {
                     
                     Page = createRandomBatchTransactionsResponseProperties.Metadata.Page,
                     TotalPages = createRandomBatchTransactionsResponseProperties.Metadata.TotalPages,
                     TotalRecords = createRandomBatchTransactionsResponseProperties.Metadata.TotalRecords
                
                 },
                Data = ((List<dynamic>)createRandomBatchTransactionsResponseProperties.Data).Select(data =>
                {
                    return new ExternalBatchTransactionsResponse.Datum
                    {
                        Id = data.Id,
                        AllReferences = data.AllReferences,
                        CreatedAt = data.CreatedAt,
                        FailedReferences = data.FailedReferences,
                        PassedReferences = data.PassedReferences,
                        Reference = data.Reference,
                        Reversed = data.Reversed,
                        Source = new ExternalBatchTransactionsResponse.Source
                        {
                             Type = data.Source.Type,
                             UserId = data.Source.UserId,
                             WalletId = data.Source.WalletId,
                        },
                        Type = data.Type,
                        UpdatedAt = data.UpdatedAt,
                    };
                }).ToList(),
                Status = createRandomBatchTransactionsResponseProperties.Status
                   
            };


   
            var randomBatchTransactionsResponse = new BatchTransactionsResponse
            {
                Metadata = new BatchTransactionsResponse.MetadataResponse
                {

                    Page = createRandomBatchTransactionsResponseProperties.Metadata.Page,
                    TotalPages = createRandomBatchTransactionsResponseProperties.Metadata.TotalPages,
                    TotalRecords = createRandomBatchTransactionsResponseProperties.Metadata.TotalRecords

                },
                Data = ((List<dynamic>)createRandomBatchTransactionsResponseProperties.Data).Select(data =>
                {
                    return new BatchTransactionsResponse.Datum
                    {
                        Id = data.Id,
                        AllReferences = data.AllReferences,
                        CreatedAt = data.CreatedAt,
                        FailedReferences = data.FailedReferences,
                        PassedReferences = data.PassedReferences,
                        Reference = data.Reference,
                        Reversed = data.Reversed,
                        Source = new BatchTransactionsResponse.Source
                        {
                            Type = data.Source.Type,
                            UserId = data.Source.UserId,
                            WalletId = data.Source.WalletId,
                        },
                        Type = data.Type,
                        UpdatedAt = data.UpdatedAt,
                    };
                }).ToList(),
                Status = createRandomBatchTransactionsResponseProperties.Status
            };



            var expectedResponse = new BatchTransactions
            {
                Response = randomBatchTransactionsResponse
            };

           

            ExternalBatchTransactionsResponse returnedExternalBatchTransactionsResponse =
                randomExternalBatchTransactionsResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBatchTransactionsAsync(inputSearch, inputCategory, inputType, inputPage, inputPerPage))
                     .ReturnsAsync(returnedExternalBatchTransactionsResponse);

            // when
            BatchTransactions actualCreateBatchTransactions =
               await this.transactionsService.GetBatchTransactionsRequestAsync(inputSearch, inputCategory, inputType, inputPage, inputPerPage);

            // then
            actualCreateBatchTransactions.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetBatchTransactionsAsync(inputSearch, inputCategory, inputType, inputPage, inputPerPage),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
