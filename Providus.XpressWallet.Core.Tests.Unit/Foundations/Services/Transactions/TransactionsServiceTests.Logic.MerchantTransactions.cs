using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {
        [Fact]
        public async Task ShouldPostMerchantTransactionsWithMerchantTransactionsRequestAsync()
        {
            // given 
            var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputStatus = GetRandomString();

            dynamic createRandomMerchantTransactionsResponseProperties =
                CreateRandomMerchantTransactionsResponseProperties();



            var randomExternalMerchantTransactionsResponse = new ExternalMerchantTransactionsResponse
            {
                    
                 Metadata = new ExternalMerchantTransactionsResponse.ExternalMetadata
                 {
                     Amount = createRandomMerchantTransactionsResponseProperties.Metadata.Amount,
                     Bvn = createRandomMerchantTransactionsResponseProperties.Metadata.Bvn,
                     BVNFirstName = createRandomMerchantTransactionsResponseProperties.Metadata.BVNFirstName,
                     BVNLastName = createRandomMerchantTransactionsResponseProperties.Metadata.BVNLastName,
                     Currency = createRandomMerchantTransactionsResponseProperties.Metadata.Currency,
                     CustomerName = createRandomMerchantTransactionsResponseProperties.Metadata.CustomerName,
                     CustomerWallet = createRandomMerchantTransactionsResponseProperties.Metadata.CustomerWallet,
                     DateOfBirth = createRandomMerchantTransactionsResponseProperties.Metadata.DateOfBirth,
                     DestinationAccountNumber = createRandomMerchantTransactionsResponseProperties.Metadata.DestinationAccountNumber,
                     DestinationBankCode = createRandomMerchantTransactionsResponseProperties.Metadata.DestinationBankCode,
                     Email = createRandomMerchantTransactionsResponseProperties.Metadata.Email,
                     FirstName = createRandomMerchantTransactionsResponseProperties.Metadata.FirstName,
                     LastName = createRandomMerchantTransactionsResponseProperties.Metadata.LastName,
                     NameMatch = createRandomMerchantTransactionsResponseProperties.Metadata.NameMatch,
                     Page = createRandomMerchantTransactionsResponseProperties.Metadata.Page,
                     PhoneNumber = createRandomMerchantTransactionsResponseProperties.Metadata.PhoneNumber,
                     TotalPages = createRandomMerchantTransactionsResponseProperties.Metadata.TotalPages,
                     TotalRecords = createRandomMerchantTransactionsResponseProperties.Metadata.TotalRecords
                
                 },
                 Transactions = ((List<dynamic>)createRandomMerchantTransactionsResponseProperties.Transactions).Select(transactions =>
                 {
                     return new ExternalMerchantTransactionsResponse.Transaction
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
                         Metadata = new ExternalMerchantTransactionsResponse.ExternalMetadata
                         {
                             Amount = transactions.Metadata.Amount,
                             Bvn = transactions.Metadata.Bvn,
                             BVNFirstName = transactions.Metadata.Bvn,
                             BVNLastName = transactions.Metadata.Bvn,
                             Currency = transactions.Metadata.Currency,
                             CustomerName = transactions.Metadata.CustomerName,
                             CustomerWallet = transactions.Metadata.CustomerWallet,
                             DateOfBirth = transactions.Metadata.DateOfBirth,
                             DestinationAccountNumber = transactions.Metadata.DestinationAccountNumber,
                             DestinationBankCode = transactions.Metadata.DestinationBankCode,
                             Email = transactions.Metadata.Email,
                             FirstName = transactions.Metadata.FirstName,
                             LastName = transactions.Metadata.LastName,
                             NameMatch = transactions.Metadata.NameMatch,
                             Page = transactions.Metadata.Page,
                             PhoneNumber = transactions.Metadata.PhoneNumber,
                             TotalPages = transactions.Metadata.TotalPages,
                             TotalRecords = transactions.Metadata.TotalRecords,

                         },
                         Mode = transactions.Mode,
                         Reference = transactions.Reference,
                         Source = transactions.Source,
                         Type = transactions.Type,
                         UpdatedAt = transactions.UpdatedAt,
                         
                     };
                 }).ToList(),
                Status = createRandomMerchantTransactionsResponseProperties.Status
                   
            };


   
            var randomMerchantTransactionsResponse = new MerchantTransactionsResponse
            {
                Metadata = new MerchantTransactionsResponse.MetadataResponse
                {
                    Amount = createRandomMerchantTransactionsResponseProperties.Metadata.Amount,
                    Bvn = createRandomMerchantTransactionsResponseProperties.Metadata.Bvn,
                    BVNFirstName = createRandomMerchantTransactionsResponseProperties.Metadata.BVNFirstName,
                    BVNLastName = createRandomMerchantTransactionsResponseProperties.Metadata.BVNLastName,
                    Currency = createRandomMerchantTransactionsResponseProperties.Metadata.Currency,
                    CustomerName = createRandomMerchantTransactionsResponseProperties.Metadata.CustomerName,
                    CustomerWallet = createRandomMerchantTransactionsResponseProperties.Metadata.CustomerWallet,
                    DateOfBirth = createRandomMerchantTransactionsResponseProperties.Metadata.DateOfBirth,
                    DestinationAccountNumber = createRandomMerchantTransactionsResponseProperties.Metadata.DestinationAccountNumber,
                    DestinationBankCode = createRandomMerchantTransactionsResponseProperties.Metadata.DestinationBankCode,
                    Email = createRandomMerchantTransactionsResponseProperties.Metadata.Email,
                    FirstName = createRandomMerchantTransactionsResponseProperties.Metadata.FirstName,
                    LastName = createRandomMerchantTransactionsResponseProperties.Metadata.LastName,
                    NameMatch = createRandomMerchantTransactionsResponseProperties.Metadata.NameMatch,
                    Page = createRandomMerchantTransactionsResponseProperties.Metadata.Page,
                    PhoneNumber = createRandomMerchantTransactionsResponseProperties.Metadata.PhoneNumber,
                    TotalPages = createRandomMerchantTransactionsResponseProperties.Metadata.TotalPages,
                    TotalRecords = createRandomMerchantTransactionsResponseProperties.Metadata.TotalRecords
                },
                Transactions = ((List<dynamic>)createRandomMerchantTransactionsResponseProperties.Transactions).Select(transactions =>
                {
                    return new MerchantTransactionsResponse.Transaction
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
                        Metadata = new MerchantTransactionsResponse.MetadataResponse
                        {
                            Amount = transactions.Metadata.Amount,
                            Bvn = transactions.Metadata.Bvn,
                            BVNFirstName = transactions.Metadata.Bvn,
                            BVNLastName = transactions.Metadata.Bvn,
                            Currency = transactions.Metadata.Currency,
                            CustomerName = transactions.Metadata.CustomerName,
                            CustomerWallet = transactions.Metadata.CustomerWallet,
                            DateOfBirth = transactions.Metadata.DateOfBirth,
                            DestinationAccountNumber = transactions.Metadata.DestinationAccountNumber,
                            DestinationBankCode = transactions.Metadata.DestinationBankCode,
                            Email = transactions.Metadata.Email,
                            FirstName = transactions.Metadata.FirstName,
                            LastName = transactions.Metadata.LastName,
                            NameMatch = transactions.Metadata.NameMatch,
                            Page = transactions.Metadata.Page,
                            PhoneNumber = transactions.Metadata.PhoneNumber,
                            TotalPages = transactions.Metadata.TotalPages,
                            TotalRecords = transactions.Metadata.TotalRecords,

                        },
                        Mode = transactions.Mode,
                        Reference = transactions.Reference,
                        Source = transactions.Source,
                        Type = transactions.Type,
                        UpdatedAt = transactions.UpdatedAt,

                    };
                }).ToList(),
                Status = createRandomMerchantTransactionsResponseProperties.Status

            };



            var expectedResponse = new MerchantTransactions
            {
                Response = randomMerchantTransactionsResponse
            };

           

            ExternalMerchantTransactionsResponse returnedExternalMerchantTransactionsResponse =
                randomExternalMerchantTransactionsResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetMerchantTransactionsAsync(inputPage, inputType,inputStatus))
                     .ReturnsAsync(returnedExternalMerchantTransactionsResponse);

            // when
            MerchantTransactions actualCreateMerchantTransactions =
               await this.transactionsService.GetMerchantTransactionsRequestAsync(inputPage, inputType,inputStatus);

            // then
            actualCreateMerchantTransactions.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetMerchantTransactionsAsync(inputPage, inputType,inputStatus),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
