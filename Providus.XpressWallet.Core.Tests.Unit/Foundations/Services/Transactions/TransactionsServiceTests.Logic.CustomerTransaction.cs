using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {
        [Fact]
        public async Task ShouldPostCustomerTransactionsWithCustomerTransactionsRequestAsync()
        {
            // given 
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputCustomerId = GetRandomString();

            dynamic createRandomCustomerTransactionsResponseProperties =
                CreateRandomCustomerTransactionsResponseProperties();



            var randomExternalCustomerTransactionsResponse = new ExternalCustomerTransactionsResponse
            {
                    
                 Metadata = new ExternalCustomerTransactionsResponse.ExternalMetadata
                 {
                     
                     Page = createRandomCustomerTransactionsResponseProperties.Metadata.Page,
                     TotalPages = createRandomCustomerTransactionsResponseProperties.Metadata.TotalPages,
                     TotalRecords = createRandomCustomerTransactionsResponseProperties.Metadata.TotalRecords
                
                 },
                 Transactions = ((List<dynamic>)createRandomCustomerTransactionsResponseProperties.Transactions).Select(transactions =>
                 {
                     return new ExternalCustomerTransactionsResponse.Transaction
                     {
                         Amount = transactions.Amount,
                         BalanceAfter = transactions.BalanceAfter,
                         BalanceBefore = transactions.BalanceBefore,
                         Category = transactions.Category,
                         Completed = transactions.Completed,
                         CreatedAt = transactions.CreatedAt,
                         Currency = transactions.Currency,
                         Description = transactions.Description,
                         Destination = transactions.Destination,
                         Id = transactions.Id,
                         Metadata = transactions.Metadata,
                         Mode = transactions.Mode,
                         Reference = transactions.Reference,
                         Source = transactions.Source,
                         Type = transactions.Type,
                         UpdatedAt = transactions.UpdatedAt,
                         UserId = transactions.UserId,
                         
                     };
                 }).ToList(),
                Status = createRandomCustomerTransactionsResponseProperties.Status
                   
            };


   
            var randomCustomerTransactionsResponse = new CustomerTransactionsResponse
            {
                Metadata = new CustomerTransactionsResponse.MetadataResponse
                {

                    Page = createRandomCustomerTransactionsResponseProperties.Metadata.Page,
                    TotalPages = createRandomCustomerTransactionsResponseProperties.Metadata.TotalPages,
                    TotalRecords = createRandomCustomerTransactionsResponseProperties.Metadata.TotalRecords

                },
                Transactions = ((List<dynamic>)createRandomCustomerTransactionsResponseProperties.Transactions).Select(transactions =>
                {
                    return new CustomerTransactionsResponse.Transaction
                    {
                        Amount = transactions.Amount,
                        BalanceAfter = transactions.BalanceAfter,
                        BalanceBefore = transactions.BalanceBefore,
                        Category = transactions.Category,
                        Completed = transactions.Completed,
                        CreatedAt = transactions.CreatedAt,
                        Currency = transactions.Currency,
                        Description = transactions.Description,
                        Destination = transactions.Destination,
                        Id = transactions.Id,
                        Metadata = transactions.Metadata,
                        Mode = transactions.Mode,
                        Reference = transactions.Reference,
                        Source = transactions.Source,
                        Type = transactions.Type,
                        UpdatedAt = transactions.UpdatedAt,
                        UserId = transactions.UserId,

                    };
                }).ToList(),
                Status = createRandomCustomerTransactionsResponseProperties.Status

            };



            var expectedResponse = new CustomerTransactions
            {
                Response = randomCustomerTransactionsResponse
            };

           

            ExternalCustomerTransactionsResponse returnedExternalCustomerTransactionsResponse =
                randomExternalCustomerTransactionsResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetCustomerTransactionsAsync(inputCustomerId, inputPage, inputType, inputPerPage))
                     .ReturnsAsync(returnedExternalCustomerTransactionsResponse);

            // when
            CustomerTransactions actualCreateCustomerTransactions =
               await this.transactionsService.GetCustomerTransactionsRequestAsync(inputCustomerId, inputPage, inputType, inputPerPage);

            // then
            actualCreateCustomerTransactions.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetCustomerTransactionsAsync(inputCustomerId, inputPage, inputType, inputPerPage),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
