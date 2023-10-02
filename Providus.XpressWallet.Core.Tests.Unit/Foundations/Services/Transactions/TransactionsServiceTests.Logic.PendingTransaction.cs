using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {
        [Fact]
        public async Task ShouldPostPendingTransactionWithPendingTransactionRequestAsync()
        {
            // given 
            var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputStatus = GetRandomString();

            dynamic createRandomPendingTransactionResponseProperties =
                CreateRandomPendingTransactionResponseProperties();



            var randomExternalPendingTransactionResponse = new ExternalPendingTransactionResponse
            {
                    
                 Metadata = new ExternalPendingTransactionResponse.ExternalMetadata
                 {
                     Amount = createRandomPendingTransactionResponseProperties.Metadata.Amount,
                     SortCode = createRandomPendingTransactionResponseProperties.Metadata.SortCode,
                     Narration = createRandomPendingTransactionResponseProperties.Metadata.Narration,
                     AccountName = createRandomPendingTransactionResponseProperties.Metadata.AccountName,
                     AccountNumber = createRandomPendingTransactionResponseProperties.Metadata.AccountNumber,
                     BankName = createRandomPendingTransactionResponseProperties.Metadata.BankName,
                     CustomData = new ExternalPendingTransactionResponse.CustomData
                     {
                         CustomerData = createRandomPendingTransactionResponseProperties.Metadata.CustomData.CustomerData
                     },
                     CustomerId = createRandomPendingTransactionResponseProperties.Metadata.CustomerId,
                     Page = createRandomPendingTransactionResponseProperties.Metadata.Page,
                     TotalPages = createRandomPendingTransactionResponseProperties.Metadata.TotalPages,
                     TotalRecords = createRandomPendingTransactionResponseProperties.Metadata.TotalRecords
                
                 },
                 Data = ((List<dynamic>)createRandomPendingTransactionResponseProperties.Data).Select(data =>
                 {
                     return new ExternalPendingTransactionResponse.Datum
                     {
                         Amount = data.Amount,
                         ApprovedBy = data.ApprovedBy,
                         Category = data.Category,
                         CreatedAt = data.CreatedAt,
                         Creator = data.Creator,
                         Id = data.Id,
                         MerchantId = data.MerchantId,
                         Metadata = new ExternalPendingTransactionResponse.ExternalMetadata
                         {
                             AccountName = data.Metadata.AccountName,
                             AccountNumber = data.Metadata.AccountNumber,
                             Amount = data.Metadata.Amount,
                             BankName = data.Metadata.BankName,
                             CustomData = new ExternalPendingTransactionResponse.CustomData
                             {
                                 CustomerData = data.Metadata.CustomData.CustomerData,

                             },
                             CustomerId = data.Metadata.CustomerId,
                             Narration = data.Metadata.Narration,
                             Page = data.Metadata.Page,
                             SortCode = data.Metadata.SortCode,
                             TotalPages = data.Metadata.TotalPages,
                             TotalRecords = data.Metadata.TotalRecords,
                         },
                         Mode = data.Mode,
                         Status = data.Status,
                         Type = data.Type,
                         UpdatedAt = data.UpdatedAt,
                     };
                 }).ToList(),
                 Status = createRandomPendingTransactionResponseProperties.Status
                   
            };


   
            var randomPendingTransactionResponse = new PendingTransactionResponse
            {
                Metadata = new PendingTransactionResponse.MetadataResponse
                {
                    Amount = createRandomPendingTransactionResponseProperties.Metadata.Amount,
                    SortCode = createRandomPendingTransactionResponseProperties.Metadata.SortCode,
                    Narration = createRandomPendingTransactionResponseProperties.Metadata.Narration,
                    AccountName = createRandomPendingTransactionResponseProperties.Metadata.AccountName,
                    AccountNumber = createRandomPendingTransactionResponseProperties.Metadata.AccountNumber,
                    BankName = createRandomPendingTransactionResponseProperties.Metadata.BankName,
                    CustomData = new PendingTransactionResponse.CustomData
                    {
                        CustomerData = createRandomPendingTransactionResponseProperties.Metadata.CustomData.CustomerData
                    },
                    CustomerId = createRandomPendingTransactionResponseProperties.Metadata.CustomerId,
                    Page = createRandomPendingTransactionResponseProperties.Metadata.Page,
                    TotalPages = createRandomPendingTransactionResponseProperties.Metadata.TotalPages,
                    TotalRecords = createRandomPendingTransactionResponseProperties.Metadata.TotalRecords

                },
                Data = ((List<dynamic>)createRandomPendingTransactionResponseProperties.Data).Select(data =>
                {
                    return new PendingTransactionResponse.Datum
                    {
                        Amount = data.Amount,
                        ApprovedBy = data.ApprovedBy,
                        Category = data.Category,
                        CreatedAt = data.CreatedAt,
                        Creator = data.Creator,
                        Id = data.Id,
                        MerchantId = data.MerchantId,
                        Metadata = new PendingTransactionResponse.MetadataResponse
                        {
                            AccountName = data.Metadata.AccountName,
                            AccountNumber = data.Metadata.AccountNumber,
                            Amount = data.Metadata.Amount,
                            BankName = data.Metadata.BankName,
                            CustomData = new PendingTransactionResponse.CustomData
                            {
                                CustomerData = data.Metadata.CustomData.CustomerData,

                            },
                            CustomerId = data.Metadata.CustomerId,
                            Narration = data.Metadata.Narration,
                            Page = data.Metadata.Page,
                            SortCode = data.Metadata.SortCode,
                            TotalPages = data.Metadata.TotalPages,
                            TotalRecords = data.Metadata.TotalRecords,
                        },
                        Mode = data.Mode,
                        Status = data.Status,
                        Type = data.Type,
                        UpdatedAt = data.UpdatedAt,
                    };
                 }).ToList(),
                Status = createRandomPendingTransactionResponseProperties.Status

            };



            var expectedResponse = new PendingTransaction
            {
                Response = randomPendingTransactionResponse
            };

           

            ExternalPendingTransactionResponse returnedExternalPendingTransactionResponse =
                randomExternalPendingTransactionResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetPendingTransactionsAsync(inputPage, inputType))
                     .ReturnsAsync(returnedExternalPendingTransactionResponse);

            // when
            PendingTransaction actualCreatePendingTransaction =
               await this.transactionsService.GetPendingTransactionsRequestAsync(inputPage, inputType);

            // then
            actualCreatePendingTransaction.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetPendingTransactionsAsync(inputPage, inputType),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
