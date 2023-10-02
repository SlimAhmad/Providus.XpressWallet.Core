using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {
        [Fact]
        public async Task ShouldPostDownloadMerchantTransactionWithDownloadMerchantTransactionRequestAsync()
        {
            // given 
           


            dynamic createRandomDownloadMerchantTransactionResponseProperties =
                CreateRandomDownloadMerchantTransactionResponseProperties();



            var randomExternalDownloadMerchantTransactionResponse = new ExternalDownloadMerchantTransactionResponse
            {
                Data = ((List<dynamic>)createRandomDownloadMerchantTransactionResponseProperties.Data).Select(data =>
                {
                    return new ExternalDownloadMerchantTransactionResponse.Datum
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
                        Metadata = data.Metadata,
                        Reference = data.Reference,
                        Source = data.Source,
                        Status = data.Status,
                        Total = data.Total,
                        Type = data.Type,
                        UpdatedAt = data.UpdatedAt,
                        Vat = data.Vat,
                        
                    };
                }).ToList(),
               
                Status = createRandomDownloadMerchantTransactionResponseProperties.Status

            };



            var randomDownloadMerchantTransactionResponse = new DownloadMerchantTransactionResponse
            {
                Data = ((List<dynamic>)createRandomDownloadMerchantTransactionResponseProperties.Data).Select(data =>
                {
                    return new DownloadMerchantTransactionResponse.Datum
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
                        Metadata = data.Metadata,
                        Reference = data.Reference,
                        Source = data.Source,
                        Status = data.Status,
                        Total = data.Total,
                        Type = data.Type,
                        UpdatedAt = data.UpdatedAt,
                        Vat = data.Vat,

                    };
                }).ToList(),

                Status = createRandomDownloadMerchantTransactionResponseProperties.Status
            };



            var expectedResponse = new DownloadMerchantTransaction
            {
                Response = randomDownloadMerchantTransactionResponse
            };



            ExternalDownloadMerchantTransactionResponse returnedExternalDownloadMerchantTransactionResponse =
                randomExternalDownloadMerchantTransactionResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetDownloadMerchantTransactionAsync())
                     .ReturnsAsync(returnedExternalDownloadMerchantTransactionResponse);

            // when
            DownloadMerchantTransaction actualCreateDownloadMerchantTransaction =
               await this.transactionsService.GetDownloadMerchantTransactionRequestAsync();

            // then
            actualCreateDownloadMerchantTransaction.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetDownloadMerchantTransactionAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
