using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {
        [Fact]
        public async Task ShouldPostDownloadCustomerTransactionWithDownloadCustomerTransactionRequestAsync()
        {
            // given 
            var inputCustomerId = GetRandomString();
          

            dynamic createRandomDownloadCustomerTransactionResponseProperties =
                CreateRandomDownloadCustomerTransactionResponseProperties();



            var randomExternalDownloadCustomerTransactionResponse = new ExternalDownloadCustomerTransactionResponse
            {
                Data = ((List<dynamic>)createRandomDownloadCustomerTransactionResponseProperties.Data).Select(data =>
                {
                    return new ExternalDownloadCustomerTransactionResponse.Datum 
                    { 
                        Id = data.Id, 
                        Amount = data.Amount,
                        BalanceAfter = data.BalanceAfter,
                        BalanceBefore = data.BalanceBefore,
                        Category = data.Category,
                        CreatedAt = data.CreatedAt,
                        Currency = data.Currency,
                        Description = data.Description,
                        Destination = data.Destination,
                        Fee = data.Fee,
                        Reference = data.Reference,
                        Source = data.Source,
                        Status = data.Status,
                        Total = data.Total,
                        Type = data.Type,
                        UpdatedAt = data.UpdatedAt,
                        Vat = data.Vat,
                        Metadata = new ExternalDownloadCustomerTransactionResponse.Metadata
                        {
                           CustomerWallet = data.Metadata.CustomerWallet,
                           BankName = data.Metadata.BankName,
                           Charges = data.Metadata.Charges,
                           MerchantId = data.Metadata.MerchantId,
                           NameEnquiryRef = data.Metadata.NameEnquiryRef,
                           SessionID = data.Metadata.SessionID,
                           TotalAmount = data.Metadata.TotalAmount,
                           Vat = data.Metadata.Vat,
                           WalletAccountName = data.Metadata.WalletAccountName,
                           WalletAccountNumber = data.Metadata.WalletAccountNumber,
                           WalletId = data.Metadata.WalletId,
                           CustomerId = data.Metadata.CustomerId,
                           CustomerName = data.Metadata.CustomerName,
                           Fee = data.Metadata.Fee,
                           Narration = data.Metadata.Narration,
                           SortCode = data.Metadata.SortCode,
                           SourceCustomerId = data.Metadata.SourceCustomerId,
                           SourceCustomerWallet = data.Metadata.SourceCustomerWallet,
                           TargetCustomerId = data.Metadata.TargetCustomerId,
                           TargetCustomerWallet = data.Metadata.TargetCustomerWallet,
                           AdditionalMetadata = new ExternalDownloadCustomerTransactionResponse.AdditionalMetadata
                           {
                              CustomerData = data.Metadata.AdditionalMetadata.CustomerData,
                           },
                           AccountName = data.Metadata.AccountName,
                           AccountNumber = data.Metadata.AccountNumber,
                           Amount = data.Metadata.Amount,
                           CustomData = new ExternalDownloadCustomerTransactionResponse.CustomData
                           {
                               
                               MoreData = data.Metadata.CustomData.MoreData,
                               SomeData = data.Metadata.CustomData.SomeData,
                           },
                    
                              
                        },
                    
                    };
                }).ToList(), 
                Status = createRandomDownloadCustomerTransactionResponseProperties.Status
                   
            };


   
            var randomDownloadCustomerTransactionResponse = new DownloadCustomerTransactionResponse
            {
                Data = ((List<dynamic>)createRandomDownloadCustomerTransactionResponseProperties.Data).Select(data =>
                {
                    return new DownloadCustomerTransactionResponse.Datum
                    {
                        Id = data.Id,
                        Amount = data.Amount,
                        BalanceAfter = data.BalanceAfter,
                        BalanceBefore = data.BalanceBefore,
                        Category = data.Category,
                        CreatedAt = data.CreatedAt,
                        Currency = data.Currency,
                        Description = data.Description,
                        Destination = data.Destination,
                        Fee = data.Fee,
                        Metadata = new DownloadCustomerTransactionResponse.Metadata
                        {
                            CustomerWallet = data.Metadata.CustomerWallet,
                            BankName = data.Metadata.BankName,
                            Charges = data.Metadata.Charges,
                            MerchantId = data.Metadata.MerchantId,
                            NameEnquiryRef = data.Metadata.NameEnquiryRef,
                            SessionID = data.Metadata.SessionID,
                            TotalAmount = data.Metadata.TotalAmount,
                            Vat = data.Metadata.Vat,
                            WalletAccountName = data.Metadata.WalletAccountName,
                            WalletAccountNumber = data.Metadata.WalletAccountNumber,
                            WalletId = data.Metadata.WalletId,
                            AdditionalMetadata = new DownloadCustomerTransactionResponse.AdditionalMetadata
                            {
                                CustomerData = data.Metadata.AdditionalMetadata.CustomerData,
                            },
                            AccountName = data.Metadata.AccountName,
                            AccountNumber = data.Metadata.AccountNumber,
                            Amount = data.Metadata.Amount,
                            CustomData = new DownloadCustomerTransactionResponse.CustomData
                            {

                                MoreData = data.Metadata.CustomData.MoreData,
                                SomeData = data.Metadata.CustomData.SomeData,
                            },
                            CustomerId = data.Metadata.CustomerId,
                            CustomerName = data.Metadata.CustomerName,
                            Fee = data.Metadata.Fee,
                            Narration = data.Metadata.Narration,
                            SortCode = data.Metadata.SortCode,
                            SourceCustomerId = data.Metadata.SourceCustomerId,
                            SourceCustomerWallet = data.Metadata.SourceCustomerWallet,
                            TargetCustomerId = data.Metadata.TargetCustomerId,
                            TargetCustomerWallet = data.Metadata.TargetCustomerWallet,


                        },
                        Reference = data.Reference,
                        Source = data.Source,
                        Status = data.Status,
                        Total = data.Total,
                        Type = data.Type,
                        UpdatedAt = data.UpdatedAt,
                        Vat = data.Vat,
                    };
                }).ToList(),
                Status = createRandomDownloadCustomerTransactionResponseProperties.Status
            };



            var expectedResponse = new DownloadCustomerTransaction
            {
                Response = randomDownloadCustomerTransactionResponse
            };

           

            ExternalDownloadCustomerTransactionResponse returnedExternalDownloadCustomerTransactionResponse =
                randomExternalDownloadCustomerTransactionResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetDownloadCustomerTransactionAsync(inputCustomerId))
                     .ReturnsAsync(returnedExternalDownloadCustomerTransactionResponse);

            // when
            DownloadCustomerTransaction actualCreateDownloadCustomerTransaction =
               await this.transactionsService.GetDownloadCustomerTransactionRequestAsync(inputCustomerId);

            // then
            actualCreateDownloadCustomerTransaction.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetDownloadCustomerTransactionAsync(inputCustomerId),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
